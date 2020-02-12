using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpServices
{
    public class HttpService : IHttpService
    {
        public async Task<T> GetRequestAsync<T>(string url) where T : class
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));

            T result = default(T);
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false
            };

            using (var httpClient = new HttpClient(handler))
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<T>(apiResponse);
                    }
                }
            }

            return result;
        }
    }
}