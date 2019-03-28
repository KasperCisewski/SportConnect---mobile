using System;
using Polly;
using RestSharp;

namespace SportConnect.Core.Services.Http.ClientService
{
    public class PollyPolicyService : IPollyPolicyService
    {
        public IAsyncPolicy GetHttpRequestPolicy(IRestRequest request)
        {
            if (request.Method == Method.GET)
            {
                return Policy.Handle<Exception>().RetryAsync(3);
            }

            return Policy.NoOpAsync();
        }
    }
}
