using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    /// <summary>
    /// https://docs.openstack.org/api-ref/identity/v3/index.html#policies
    /// </summary>
    public class PolicyService : AbstractService
    {
        public PolicyService(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// Create policy
        /// </summary>
        public async Task<Response<JObject>> Create(string token, Policy policy)
        {
            var form = new { policy };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/policies",
                Method = HttpMethod.Post,
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// List policies
        /// </summary>
        public async Task<Response<JObject>> List(string token)
        {
            var request = new Request
            {
                Uri = "/v3/policies",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Show policy details
        /// </summary>
        public async Task<Response<JObject>> Details(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/policies/{id}",
                Method = HttpMethod.Get,
                Token = token
            };
            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Update policy
        /// </summary>
        public async Task<Response<JObject>> Update(string token, string id, UpdatePolicy policy)
        {
            var form = new { policy };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/policies/{id}",
                Method = new HttpMethod("PATCH"),
                Token = token,
                Body = body
            };
            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Delete policies
        /// </summary>
        public async Task<Response<JObject>> Delete(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/policies/{id}",
                Method = HttpMethod.Delete,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }
    }

    public class Policy
    {
        [JsonProperty("blob")]
        public string Blob { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Blob
    {
        [JsonProperty("foobar_user")]
        public List<string> FoobarUser { get; set; }
    }

    public class UpdatePolicy
    {
        [JsonProperty("blob")]
        public Blob Blob { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}