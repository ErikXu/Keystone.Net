using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    /// <summary>
    /// https://docs.openstack.org/api-ref/identity/v3/index.html?expanded=#service-catalog-and-endpoints
    /// </summary>
    public class ServiceEndpointService : AbstractService
    {
        public ServiceEndpointService(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// List endpoints
        /// </summary>
        public async Task<Response<JObject>> List(string token)
        {
            var request = new Request
            {
                Uri = "/v3/endpoints",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Create endpoint
        /// </summary>
        public async Task<Response<JObject>> Create(string token, Endpoint endpoint)
        {
            var form = new { endpoint };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/endpoints",
                Method = HttpMethod.Post,
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Show endpoint details
        /// </summary>
        public async Task<Response<JObject>> Details(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/endpoints/{id}",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Update endpoint
        /// </summary>
        public async Task<Response<JObject>> Update(string token, string id, Endpoint endpoint)
        {
            var form = new { endpoint };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/endpoints/{id}",
                Method = new HttpMethod("PATCH"),
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        ///  Delete endpoint
        /// </summary>
        public async Task<Response<JObject>> Delete(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/endpoints/{id}",
                Method = HttpMethod.Delete,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }
    }

    public class Endpoint
    {
        [JsonProperty("interface")]
        public string Connector { get; set; }

        [JsonProperty("region_id")]
        public string RegionId { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}