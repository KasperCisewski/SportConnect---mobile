using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SportConnect.Core.Services.Http.HttpFactory;
using SportConnect.Core.Services.Logger;
using SportConnect.Core.Services.Rest.Interfaces;

namespace SportConnect.Core.Services.Registration
{
    public class RegistrationService
    {
        private readonly ILoggerService _loggerService;
        private readonly IHttpClientServiceFactory _httpClientServiceFactory;
        private readonly IRestClient _restClient;

        private static readonly string ApiPath = $"{MvxApp.BackendUrl}/api/registration/";

        public RegistrationService(
            ILoggerService loggerService,
            IHttpClientServiceFactory httpClientServiceFactory,
            IRestClient restClient)
        {
            _loggerService = loggerService;
            _httpClientServiceFactory = httpClientServiceFactory;
            _restClient = restClient;
        }

        public async Task<bool> TryToRegisterUserAsync(RegistrationResponseApiModel registrationModel)
        {
            try
            {
                var response = await
                    _restClient.MakeApiCall<RegistationResultApiModel>
                        ($"{ApiPath}register", HttpMethod.Post, registrationModel);
                return response.IsSucces;

            }
            catch (Exception e)
            {
                _loggerService.LogError(e, $"Error during procces of user registration ");
            }
            return false;
        }
    }

    public class RegistationResultApiModel
    {
        public bool IsSucces { get; set; }
    }

    public class RegistrationResponseApiModel
    {
        public RegistrationResponseApiModel(string login, string email, string password)
        {
            Login = login;
            Email = email;
            Password = password;
        }

        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

