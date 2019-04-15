using System.Threading.Tasks;
using RestSharp;

namespace SportConnect.Core.Services.Http.ClientService
{
    public interface IHttpClientService
    {
        Task<HttpResult<T>> ExecuteAsync<T>(IRestRequest request);
        Task<HttpResult<object>> ExecuteAsync(IRestRequest request);

    }
}
