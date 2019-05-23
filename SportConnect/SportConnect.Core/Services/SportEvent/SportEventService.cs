using System;
using Plugin.Geolocator;
using SportConnect.Core.Model.SportEvents;
using SportConnect.Core.Services.Logger;
using System.Net.Http;
using SportConnect.Core.Services.Rest.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Plugin.Geolocator.Abstractions;
using SportConnect.Core.Services.GlobalStateService.Abstraction;

namespace SportConnect.Core.Services.SportEvent
{
    public class SportEventService
    {
        private static readonly string ApiPath = $"{MvxApp.BackendUrl}/api/sportEvent/";
        private readonly ILoggerService _loggerService;
        private readonly IGlobalStateService _globalStateService;
        private readonly IRestClient _restClient;

        public SportEventService(
                ILoggerService loggerService,
                IGlobalStateService globalStateService,
                IRestClient restClient)
        {
            _loggerService = loggerService;
            _globalStateService = globalStateService;
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

        public async Task<bool> IsUserJoinToEventInPast(Guid id, Guid userId)
        {
            try
            {
                var response = await
                    _restClient.MakeApiCall<IsUserAttendedToSportEventModel>
                        ($"{ApiPath}isUserJoinToEvent?id={id}&userId={userId}", HttpMethod.Get);

                return response.IsAttended;
            }
            catch (Exception e)
            {
                _loggerService.LogError(e, $"Unhandled expection on getting sport events");
            }
            return false;
        }

        public async Task OutFromEvent(Guid id, Guid userId)
        {
            try
            {
                var response = await
                    _restClient.MakeApiCall<string>
                        ($"{ApiPath}outFromEvent?id={id}&userId={userId}", HttpMethod.Put);

            }
            catch (Exception e)
            {
                _loggerService.LogError(e, $"Unhandled expection on getting sport events");
            }
        }

        public async Task JoinToEvent(Guid id, Guid userId)
        {
            try
            {
                var response = await
                     _restClient.MakeApiCall<string>
                         ($"{ApiPath}joinToEvent?id={id}&userId={userId}", HttpMethod.Put);
            }
            catch (Exception e)
            {
                _loggerService.LogError(e, $"Unhandled expection on getting sport events");
            }
        }

        public async Task<List<SportEventModel>> GetSportEventsAssignedToUser()
        {
            try
            {
                var response = await
                    _restClient.MakeApiCall<List<SportEventModel>>
                        ($"{ApiPath}getSportEventsForUser?userId={_globalStateService.UserData.UserId}", HttpMethod.Get);

                return response;
            }
            catch (Exception e)
            {
                _loggerService.LogError(e, $"Unhandled expection on getting sport events");
            }
            return new List<SportEventModel>();
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

        private class IsUserAttendedToSportEventModel
        {
            public bool IsAttended { get; set; }
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
