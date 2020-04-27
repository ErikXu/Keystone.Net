using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    /// <summary>
    /// https://docs.openstack.org/api-ref/identity/v3/index.html#regions
    /// </summary>
    public class RegionService : AbstractService
    {
        public RegionService(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// Show region details
        /// </summary>
        public async Task<Response<JObject>> Details(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/regions/{id}",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Update region
        /// </summary>
        public async Task<Response<JObject>> Update(string token, string id, Region region)
        {
            var form = new { region };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/regions/{id}",
                Method = new HttpMethod("PATCH"),
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Delete region
        /// </summary>
        public async Task<Response<JObject>> Delete(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/regions/{id}",
                Method = HttpMethod.Delete,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// List regions
        /// </summary>
        public async Task<Response<JObject>> List(string token)
        {
            var request = new Request
            {
                Uri = "/v3/regions",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Create region
        /// </summary>
        public async Task<Response<JObject>> Create(string token, Region region)
        {
            var form = new { region };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/regions",
                Method = HttpMethod.Post,
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }
    }

    public class Region
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("parent_region_id")]
        public string ParentRegionId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}