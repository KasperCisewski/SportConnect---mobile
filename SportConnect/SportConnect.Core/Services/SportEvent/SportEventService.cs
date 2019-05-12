using System;
using Plugin.Geolocator;
using System.Linq;
using SportConnect.Core.Model.SportEvents;
using SportConnect.Core.Services.Logger;
using System.Net.Http;
using SportConnect.Core.Services.Rest.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Plugin.Geolocator.Abstractions;

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

        public async Task<string> SaveSportEvent(SportEventApiModelToCreate sportEventModel)
        {
            try
            {
                var response = await
                    _restClient.MakeApiCall<string>
                        ($"{ApiPath}addNewSportEvent", HttpMethod.Post, sportEventModel);                     

                return response;
            }
            catch (Exception e)
            {
                _loggerService.LogError(e, $"Unhandled expection on getting sport events");
            }
            return string.Empty;
        }

        public async Task<List<SportEventModel>> GetSportEventsAsync(Guid userId)
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            Position position = new Position();
            if (CrossGeolocator.IsSupported && CrossGeolocator.Current.IsGeolocationAvailable && CrossGeolocator.Current.IsGeolocationAvailable)
            {
                position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
            }

            Task.WaitAll();
            try
            {
                var response = await
                    _restClient.MakeApiCall<List<SportEventModel>>
                        ($"{ApiPath}getSportEvents", HttpMethod.Post, new SportEventApiModel
                        {
                            UserId = userId,
                            Latitude = position.Latitude,
                            Longitude = position.Longitude,
                            Take = 50
                        });

                return response;
            }
            catch (Exception e)
            {
                _loggerService.LogError(e, $"Unhandled expection on getting sport events");
            }

            return new List<SportEventModel>();
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
