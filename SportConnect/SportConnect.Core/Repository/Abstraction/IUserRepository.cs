using SportConnect.Core.Model.Credentials;

namespace SportConnect.Core.Repository.Abstraction
{
    interface IUserRepository
    {
        void SaveCredentials(LoginCredentialsModel loginCredentialsModel);
        LoginCredentialsModel GetUserCredentials();
    }
}
