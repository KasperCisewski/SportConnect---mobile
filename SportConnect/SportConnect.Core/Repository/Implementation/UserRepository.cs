using SportConnect.Core.Model.Credentials;
using SportConnect.Core.Repository.Abstraction;
using SportConnect.Core.Services.SqlLite;
using SQLite;
using System.Linq;

namespace SportConnect.Core.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly SQLiteConnection UserConnectionRepository;


        public UserRepository(ISqlLiteService sqlLiteService)
        {
            UserConnectionRepository = sqlLiteService.GetConnection();
            UserConnectionRepository.CreateTable<LoginCredentialsModel>();
        }

        public LoginCredentialsModel GetUserCredentials() =>
            (from c in UserConnectionRepository.Table<LoginCredentialsModel>() select c)
            .FirstOrDefault();

        public void SaveCredentials(LoginCredentialsModel loginCredentialsModel)
        {
            UserConnectionRepository.DropTable<LoginCredentialsModel>();
            UserConnectionRepository.CreateTable<LoginCredentialsModel>();

            UserConnectionRepository.Insert(new LoginCredentialsModel()
            {
                Login = loginCredentialsModel.Login,
                Password = loginCredentialsModel.Password
            });
        }
    }
}
