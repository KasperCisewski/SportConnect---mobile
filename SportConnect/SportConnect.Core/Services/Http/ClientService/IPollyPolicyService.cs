using RestSharp;
using Polly;

namespace SportConnect.Core.Services.Http.ClientService
{
    public interface IPollyPolicyService
    {
        IAsyncPolicy GetHttpRequestPolicy(IRestRequest request);
    }
}
