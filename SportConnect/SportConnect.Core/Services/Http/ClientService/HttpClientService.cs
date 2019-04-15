using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using SportConnect.Core.Services.Logger;

namespace SportConnect.Core.Services.Http.ClientService
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IRestClient _restClient;
        private readonly IPollyPolicyService _pollyPolicyService;
        private readonly ILoggerService _loggerService;

        public HttpClientService(
            IRestClient restClient,
            IPollyPolicyService pollyPolicyService,
            ILoggerService loggerService)
        {
            _restClient = restClient;
            _pollyPolicyService = pollyPolicyService;
            _loggerService = loggerService;
        }

        public async Task<HttpResult<T>> ExecuteAsync<T>(IRestRequest request)
        {
            var policy = _pollyPolicyService.GetHttpRequestPolicy(request);
            var result = await policy.ExecuteAndCaptureAsync(async () => (await ExecuteAndThrowIfError<T>(request)));

            if (result.FinalException != null)
            {
                _loggerService.LogError(result.FinalException, "Http client error");
                return new HttpResult<T>
                {
                    Success = false,
                    ErrorMessage = result.FinalException.Message,
                    ErrorDataDictionary = new Dictionary<string, string>()
                };
            }

            return result.Result ?? new HttpResult<T>();
        }

        public async Task<HttpResult<object>> ExecuteAsync(IRestRequest request)
        {
            return await ExecuteAsync<object>(request);
        }

        private async Task<HttpResult<T>> ExecuteAndThrowIfError<T>(IRestRequest request)
        {
            var response = await _restClient.ExecuteTaskAsync<HttpResult<T>>(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response.Data;
        }


    }

    public class HttpResult<T>
    {
        public bool Success { get; set; }
        public T ResponseData { get; set; }
        public byte ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public Dictionary<string, string> ErrorDataDictionary { get; set; }
    }
}
