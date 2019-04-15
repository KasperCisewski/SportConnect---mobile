using System;
using System.Net.Http;
using System.Threading.Tasks;
using SportConnect.Core.Services.Http.ClientService;
using SportConnect.Core.Services.Http.HttpFactory;
using SportConnect.Core.Services.Logger;
using SportConnect.Core.Services.Rest.Interfaces;

namespace SportConnect.Core.Services.User
{
    public class UserService
    {
        private readonly ILoggerService _loggerService;
        private readonly IHttpClientServiceFactory _httpClientServiceFactory;
        private readonly IRestClient _restClient;

        public UserService(
            ILoggerService loggerService,
            IHttpClientServiceFactory httpClientServiceFactory,
                IRestClient restClient)
        {
            _loggerService = loggerService;
            _httpClientServiceFactory = httpClientServiceFactory;
            _restClient = restClient;
        }

        public async Task<bool> LogIntoApp(string login, string password)
        {
            try
            {
                var response = await
                    _restClient.MakeApiCall<LoginApiModel>($"{MvxApp.BackendUrl}/api/user/signIn?login={login}&password={password}", HttpMethod.Get);

                return response.IsLogged;

            }
            catch (Exception e)
            {
                _loggerService.LogError(e, $"Wrong error or password for login {login} and password {password} ");
            }

            return false;
        }
    }

    public class LoginApiModel
    {
        public bool IsLogged { get; set; }
    }
}
