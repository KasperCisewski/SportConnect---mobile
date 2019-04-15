using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Base;
using MvvmCross.Logging;
using SportConnect.Core.Services.Rest.Interfaces;

namespace SportConnect.Core.Services.Rest.Implementations
{
    public class RestClient : IRestClient
    {
        private readonly IMvxJsonConverter _jsonConverter;
        private readonly IMvxLog _mvxLog;

        public RestClient(IMvxJsonConverter jsonConverter, IMvxLog mvxLog)
        {
            _jsonConverter = jsonConverter;
            _mvxLog = mvxLog;
        }

        public async Task<TResult> MakeApiCall<TResult>(string requestUri, HttpMethod method, object data = null) where TResult : class
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(requestUri),
                    Method = method,
                };

                // add content
                if (method != HttpMethod.Get)
                {
                    var json = _jsonConverter.SerializeObject(data);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }

                var response = new HttpResponseMessage();
                try
                {
                    response = await httpClient.SendAsync(request).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    _mvxLog.ErrorException("MakeApiCall failed", ex);
                }
                response.EnsureSuccessStatusCode();

                if (response.Content != null)
                {
                    var stringSerialized = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    // deserialize content
                    return _jsonConverter.DeserializeObject<TResult>(stringSerialized);
                }

                return null;
            }
        }
    }
}
