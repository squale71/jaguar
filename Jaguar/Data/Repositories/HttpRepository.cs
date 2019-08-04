using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Jaguar.Data.Repositories
{
    public abstract class HttpRepository
    {
        public async Task<T> GetData<T>(string baseUri, string path, Dictionary<string, string> headers) where T : new()
        {
            var baseAddress = new Uri(baseUri);
            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                foreach (var pair in headers)
                {
                    client.DefaultRequestHeaders.Add(pair.Key, pair.Value);
                }
                
                var result = await client.GetAsync(baseUri + path);

                result.EnsureSuccessStatusCode();

                var res = await result.Content.ReadAsStringAsync();

                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(res);
            }
        }
    }
}
