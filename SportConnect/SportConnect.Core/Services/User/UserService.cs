using System;
using System.Net.Http;
using System.Threading.Tasks;
using SportConnect.Core.Services.Logger;
using SportConnect.Core.Services.Rest.Interfaces;

namespace SportConnect.Core.Services.User
{
    public class UserService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRestClient _restClient;

        private static readonly string ApiPath = $"{MvxApp.BackendUrl}/api/user/";

        public UserService(
            ILoggerService loggerService,
                IRestClient restClient)
        {
            _loggerService = loggerService;
            _restClient = restClient;
        }

        public async Task<bool> TryToLogIntoApp(string login, string password)
        {
            try
            {
                var response = await
                    _restClient.MakeApiCall<LoginApiModel>
                        ($"{ApiPath}signIn?login={login}&password={password}", HttpMethod.Get);

                return response.IsLogged;
            }
            catch (Exception e)
            {
                _loggerService.LogError(e, $"Wrong error or password for login {login} and password {password} ");
            }

            return false;
        }

        public async Task<bool> ValidateEmailByCheckIfExistInApp(string email)
        {
            try
            {
                var response = await
                    _restClient.MakeApiCall<EmailExistApiModel>
                        ($"{ApiPath}isEmailExist?email={email}", HttpMethod.Get);

                return response.IsExist;
            }
            catch (Exception e)
            {
                _loggerService.LogError(e, $"Unhandled expection for email {email}");
            }

            return false;
        }

        public async Task<bool> ValidateLoginByCheckIfExistInApp(string login)
        {
            try
            {
                var response = await
                    _restClient.MakeApiCall<LoginExistApiModel>
                        ($"{ApiPath}isLoginExist?login={login}", HttpMethod.Get);

                return response.IsExist;
            }
            catch (Exception e)
            {
                _loggerService.LogError(e, $"Unhandled expection for email {login}");
            }

            return false;
        }
    }

    public class LoginExistApiModel
    {
        public bool IsExist { get; set; }
    }

    public class EmailExistApiModel
    {
        public bool IsExist { get; set; }
    }

    public class LoginApiModel
    {
        public bool IsLogged { get; set; }
    }
}
