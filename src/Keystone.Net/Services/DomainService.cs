using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    /// <summary>
    /// https://docs.openstack.org/api-ref/identity/v3/index.html?expanded=#domains
    /// </summary>
    public class DomainService : AbstractService
    {
        public DomainService(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// List domains
        /// </summary>
        public async Task<Response<DomainListResult>> List(string token)
        {
            var request = new Request
            {
                Uri = "/v3/domains",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<DomainListResult>(request);
        }

        /// <summary>
        /// Create domain
        /// </summary>
        public async Task<Response<JObject>> Create(string token, Domain domain)
        {
            var form = new { domain };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/domains",
                Method = HttpMethod.Post,
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        ///Show domain details
        /// </summary>
        public async Task<Response<JObject>> Details(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/domains/{id}",
                Method = HttpMethod.Get,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Update domain
        /// </summary>
        public async Task<Response<JObject>> Update(string token, string id, Domain domain)
        {
            var form = new { domain };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/domains/{id}",
                Method = new HttpMethod("PATCH"),
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Delete  domain
        /// </summary>
        /// <param name="token"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Response<JObject>> Delete(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/domains/{id}",
                Method = HttpMethod.Delete,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }
    }

    public class Domain
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("options")]
        public object Options { get; set; }
    }

    public class DomainListResult
    {
        [JsonProperty("domains")]
        public List<DomainListItem> Domains { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }
    }

    public class DomainListItem
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("options")]
        public object Options { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }
    }
}