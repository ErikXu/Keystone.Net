using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace Keystone.Net
{
    public abstract class AbstractService
    {
        public HttpClient Client { get; }

        protected AbstractService(HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Client = client;
        }

        protected async Task<Response<TBody>> ExecuteAsync<TBody>(Request request) where TBody : new()
        {
            if (request.Queries != null && request.Queries.Count > 0)
            {
                request.Uri = AppendQueries(request.Uri, request.Queries);
            }

            var message = new HttpRequestMessage
            {
                RequestUri = new Uri(Client.BaseAddress.AbsoluteUri.TrimEnd('/') + request.Uri),
                Method = request.Method,
                Content = new StringContent(request.Body, Encoding.UTF8, "application/json")
            };

            if (!string.IsNullOrWhiteSpace(request.Token))
            {
                message.Headers.Add("X-Auth-Token", request.Token);
            }

            if (!string.IsNullOrWhiteSpace(request.TargetToken))
            {
                message.Headers.Add("X-Subject-Token", request.TargetToken);
            }

            var result = await Client.SendAsync(message);

            var response = new Response<TBody>
            {
                StatusCode = result.StatusCode,
                IsSuccessStatusCode = result.IsSuccessStatusCode
            };

            if (!result.IsSuccessStatusCode)
            {
                response.Message = await result.Content.ReadAsStringAsync();
            }
            else
            {
                var stream = await result.Content.ReadAsStreamAsync();
                if (stream.GetType().Name.Equals("EmptyReadStream"))
                {
                    response.Body = new TBody();
                }
                else
                {
                    response.Body = stream.Length > 0 ? Deserialize<TBody>(stream) : new TBody();
                }
                
                response.Headers = result.Headers.ToDictionary(kv => kv.Key, kv => kv.Value.First());
            }

            return response;
        }

        protected string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }

        private static T Deserialize<T>(Stream stream)
        {
            using (var reader = new JsonTextReader(new StreamReader(stream)))
            {
                var serializer = new JsonSerializer();
                return (T)serializer.Deserialize(reader, typeof(T));
            }
        }

        private static string AppendQueries(string url, Dictionary<string, string> queries)
        {
            if (queries == null || queries.Count <= 0)
            {
                return url;
            }

            if (url.Contains("?"))
            {
                url = url + "&" + BuildQueries(queries);
            }
            else
            {
                url = url + "?" + BuildQueries(queries);
            }

            return url;
        }

        private static string BuildQueries(Dictionary<string, string> queries)
        {
            var queryString = new StringBuilder();
            var hasParam = false;

            foreach (var query in queries)
            {
                if (!string.IsNullOrWhiteSpace(query.Key) && !string.IsNullOrWhiteSpace(query.Value))
                {
                    if (hasParam)
                    {
                        queryString.Append("&");
                    }

                    queryString.AppendFormat("{0}={1}", query.Key, HttpUtility.UrlEncode(query.Value, Encoding.UTF8));
                    hasParam = true;
                }
            }

            return queryString.ToString();
        }
    }

    public class Links
    {
        [JsonProperty("self")]
        public string Self { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("next")]
        public object Next { get; set; }
    }
}