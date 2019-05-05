using System;
using Plugin.Geolocator;
using System.Linq;
using SportConnect.Core.Model.SportEvents;
using SportConnect.Core.Services.Logger;
using System.Net.Http;
using SportConnect.Core.Services.Rest.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SportConnect.Core.Services.SportEvent
{
    public class SportEventService
    {
        private static readonly string ApiPath = $"{MvxApp.BackendUrl}/api/sportEvent/";
        private readonly ILoggerService _loggerService;
        private readonly IRestClient _restClient;

        public SportEventService(
                ILoggerService loggerService,
                IRestClient restClient)
        {
            _loggerService = loggerService;
            _restClient = restClient;
        }

        public async Task<IQueryable<SportEventModel>> GetSportEventsAsync(Guid userId)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            var postion = await locator.GetPositionAsync(new TimeSpan(10000));

            try
            {
                var response = await
                    _restClient.MakeApiCall<IQueryable<SportEventModel>>
                        ($"{ApiPath}getSportEvents", HttpMethod.Post, new SportEventApiModel
                        {
                            UserId = userId,
                            Latitude = postion.Latitude,
                            Longitude = postion.Longitude
                        });

                return response;
            }
            catch (Exception e)
            {
                _loggerService.LogError(e, $"Unhandled expection on getting sport events");
            }

            return Enumerable.Empty<SportEventModel>().AsQueryable();
        }

        private class SportEventApiModel
        {
            public Guid UserId { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public int Take { get; set; }
            public int Skip { get; set; }
        }
    }
}
