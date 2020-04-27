using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    /// <summary>
    /// https://docs.openstack.org/api-ref/identity/v3/index.html#credentials
    /// </summary>
    public class CredentialService : AbstractService
    {
        public CredentialService(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// List credentials
        /// </summary>
        public async Task<Response<JObject>> List(string token)
        {
            var request = new Request
            {
                Uri = "/v3/credentials",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Create credential
        /// </summary>
        public async Task<Response<JObject>> Create(string token, Credential credential)
        {
            var form = new { credential };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/credentials",
                Method = HttpMethod.Post,
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Show credential details
        /// </summary>
        public async Task<Response<JObject>> Details(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/credentials/{id}",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Update credential
        /// </summary>
        public async Task<Response<JObject>> Update(string token, string id, Credential credential)
        {
            var form = new { credential };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/credentials/{id}",
                Method = new HttpMethod("PATCH"),
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Delete credential
        /// </summary>
        public async Task<Response<JObject>> Delete(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/credentials/{id}",
                Method = HttpMethod.Delete,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }
    }

    public class Credential
    {
        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("blob")]
        public string Blob { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}