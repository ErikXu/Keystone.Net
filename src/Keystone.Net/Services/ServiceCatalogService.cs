using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    /// <summary>
    /// https://docs.openstack.org/api-ref/identity/v3/index.html?expanded=#service-catalog-and-endpoints
    /// </summary>
    public class ServiceCatalogService : AbstractService
    {
        public ServiceCatalogService(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// List services
        /// </summary>
        public async Task<Response<JObject>> List(string token)
        {
            var request = new Request
            {
                Uri = "/v3/services",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Create service
        /// </summary>
        public async Task<Response<JObject>> Create(string token, Service service)
        {
            var form = new { service };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/services",
                Method = HttpMethod.Post,
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Show service details
        /// </summary>
        public async Task<Response<JObject>> Details(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/services/{id}",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Update service
        /// </summary>
        public async Task<Response<JObject>> Update(string token, string id, Service service)
        {
            var form = new { service };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/services/{id}",
                Method = new HttpMethod("PATCH"),
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        ///  Delete service
        /// </summary>
        public async Task<Response<JObject>> Delete(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/services/{id}",
                Method = HttpMethod.Delete,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }
    }

    public class Service
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}