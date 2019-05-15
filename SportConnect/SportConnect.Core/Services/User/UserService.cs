using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Acr.UserDialogs;
using SportConnect.Core.Model.Profile;
using SportConnect.Core.Model.User;
using SportConnect.Core.Services.GlobalStateService.Abstraction;
using SportConnect.Core.Services.Logger;
using SportConnect.Core.Services.Rest.Interfaces;

namespace SportConnect.Core.Services.User
{
    public class UserService
    {
        private readonly ILoggerService _loggerService;
        private readonly IRestClient _restClient;
        private readonly IGlobalStateService _globalStateService;
        private readonly IUserDialogs _userDialogs;
        private static readonly string ApiPath = $"{MvxApp.BackendUrl}/api/user/";

        public UserService(
            ILoggerService loggerService,
                IRestClient restClient,
                IGlobalStateService globalStateService,
                IUserDialogs userDialogs)
        {
            _globalStateService = globalStateService;
            _loggerService = loggerService;
            _restClient = restClient;
            _userDialogs = userDialogs;
        }

        public async Task<List<UserLogRecordModel>> GetUserLogRecords()
        {
            try
            {
                var response = await
                    _restClient.MakeApiCall<List<UserLogRecordModel>>
                        ($"{ApiPath}getUsersLogRecords", HttpMethod.Get);

                return response;
            }
            catch (Exception e)
            {
                _loggerService.LogError(e, $"Error during getting users log records");
            }

            return new List<UserLogRecordModel>();
        }

        public async Task UpdateProfileData(UserProfileModel userProfileModel)
        {
            try
            {
                var response = await
                    _restClient.MakeApiCall<UserProfileModel>
                        ($"{ApiPath}updateUserProfileData", HttpMethod.Put, userProfileModel);
            }
            catch (Exception e)
            {
                _loggerService.LogError(e, $"Error during update user profile");
            }
        }

        public async Task<UserProfileModel> GetUserProfileData()
        {
            try
            {
                var response = await
                    _restClient.MakeApiCall<UserProfileModel>
                        ($"{ApiPath}getUserProfileData?userId={_globalStateService.UserData.UserId}", HttpMethod.Get);

                return response;
            }
            catch (Exception e)
            {
                _loggerService.LogError(e, $"Error during getting user profile data");
            }

            return new UserProfileModel();
        }

        public async Task<LoginApiModel> TryToLogIntoApp(string login, string password)
        {
            try
            {
                var response = await
                    _restClient.MakeApiCall<LoginApiModel>
                        ($"{ApiPath}signIn?login={login}&password={password}", HttpMethod.Get);

                return response;
            }
            catch (Exception e)
            {
                _loggerService.LogError(e, $"Wrong error or password for login {login} and password {password} ");
            }

            return new LoginApiModel();
        }

        public async Task<List<UserModel>> GetExistingUsers()
        {
            try
            {
                var response = await
                    _restClient.MakeApiCall<List<UserModel>>
                        ($"{ApiPath}getExistingUsers", HttpMethod.Get);

                return response;
            }
            catch (Exception e)
            {
                _loggerService.LogError(e, $"Unhandled expection when getting users");
            }

            return null;
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
        public bool IsSuccess { get; set; }
        public int UserRoleId { get; set; }
        public Guid? UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
    }
}
