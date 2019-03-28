using SportConnect.Core.Services.Http.ClientService;

namespace SportConnect.Core.Services.Http.HttpFactory
{
    public interface IHttpClientServiceFactory
    {
        bool IsUrlConfigured();
        IHttpClientService GetAuthorizedClient();
        HttpClientService GetNotAuthorizedClient();
    }
}
