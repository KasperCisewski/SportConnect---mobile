using SportConnect.Core.Services.Logger;
using SportConnect.Core.Services.Rest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SportConnect.Core.Services.SportType
{
    public class SportTypeService
    {
        private static readonly string ApiPath = $"{MvxApp.BackendUrl}/api/sportType/";
        private readonly ILoggerService _loggerService;
        private readonly IRestClient _restClient;

        public SportTypeService(
                ILoggerService loggerService,
                IRestClient restClient)
        {
            _loggerService = loggerService;
            _restClient = restClient;
        }

        public async Task<List<Model.SportType.SportType>> GetSportTypes()
        {
            try
            {
                var response = await
                    _restClient.MakeApiCall<List<Model.SportType.SportType>>
                        ($"{ApiPath}getSportTypes", HttpMethod.Get);

                return response;
            }
            catch (Exception e)
            {
                _loggerService.LogError(e, $"Unhandled expection on getting sport types");
            }

            return new List<Model.SportType.SportType>();
        }
    }
}
