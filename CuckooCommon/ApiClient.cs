using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace CuckooCommon
{
    public class ApiClient : IDisposable
    {
        private HttpClient _client;
        private Jobs _apiJob { get; set; }

        public ApiClient(Jobs job)
        {

            this._client = new HttpClient();
            this._apiJob = job;

            if (job.APIRequestHeaders != null && (job.APIRequestHeaders.Count() > 0))
            {
                foreach (var header in job.APIRequestHeaders)
                {
                    _client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
        }

        public async Task<bool> SendRequest()
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(this._apiJob.Endpoint),
                Method = new HttpMethod(_apiJob.Method.ToString())
            };

            var responseMessage = await _client.SendAsync(request).ConfigureAwait(false);
            var response = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }

            throw new EndpointException((int)responseMessage.StatusCode, response);

        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
