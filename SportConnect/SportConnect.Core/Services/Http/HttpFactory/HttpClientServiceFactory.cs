using System;
using RestSharp;
using RestSharp.Authenticators;
using SportConnect.Core.Services.Http.ClientService;
using SportConnect.Core.Services.Logger;

namespace SportConnect.Core.Services.Http.HttpFactory
{
    public class HttpClientServiceFactory : IHttpClientServiceFactory
    {
        private readonly ILoggerService _loggerService;
        private readonly IPollyPolicyService _pollyPolicyService;
        //   private readonly IGlobalStateService _globalStateService;
        //    private readonly ISettingsService _settingsService;

        public HttpClientServiceFactory(
            ILoggerService loggerService,
            IPollyPolicyService pollyPolicyService
        //        IGlobalStateService globalStateService,
        //        ISettingsService settingsService
        )
        {
            _loggerService = loggerService;
            _pollyPolicyService = pollyPolicyService;
            //         _globalStateService = globalStateService;
            //    _settingsService = settingsService;
        }

        public bool IsUrlConfigured()
        {
            //return !string.IsNullOrWhiteSpace(_settingsService?.GetSettings()?.ApiUrl);
            throw new NotImplementedException();
        }

        public IHttpClientService GetAuthorizedClient()
        {
            //var client = new RestClient(_settingsService.GetSettings().ApiUrl)
            //{
            //    Authenticator =
            //        new OAuth2AuthorizationRequestHeaderAuthenticator(_globalStateService.UserData.Token, "Bearer")
            //};

            //return new HttpClientService(client, _pollyPolicyService, _loggerService);
            throw new NotImplementedException();
        }

        public HttpClientService GetNotAuthorizedClient()
        {
            //return new HttpClientService(new RestClient(_settingsService.GetSettings().ApiUrl), _pollyPolicyService,
            //    _loggerService);
            throw new NotImplementedException();
        }
    }
}
