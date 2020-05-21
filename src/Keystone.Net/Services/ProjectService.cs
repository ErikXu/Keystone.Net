using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    /// <summary>
    /// https://docs.openstack.org/api-ref/identity/v3/index.html#projects
    /// </summary>
    public class ProjectService : AbstractService
    {
        public ProjectService(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// List projects
        /// </summary>
        public async Task<Response<JObject>> List(string token, string domainId)
        {
            var request = new Request
            {
                Uri = "/v3/projects",
                Method = HttpMethod.Get,
                Token = token
            };

            request.AddQuery("domain_id", domainId);

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Create project
        /// </summary>
        public async Task<Response<JObject>> Create(string token, Project project)
        {
            var form = new { project };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/projects",
                Method = HttpMethod.Post,
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Show project details
        /// </summary>
        public async Task<Response<JObject>> Details(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/projects/{id}",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Update project
        /// </summary>
        public async Task<Response<JObject>> Update(string token, string id, Project project)
        {
            var form = new { project };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/projects/{id}",
                Method = new HttpMethod("PATCH"),
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Delete project
        /// </summary>
        public async Task<Response<JObject>> Delete(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/projects/{id}",
                Method = HttpMethod.Delete,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }
    }

    public class Project
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("domain_id")]
        public string DomainId { get; set; }

        [JsonProperty("parent_id")]
        public string ParentId { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; } = true;

        [JsonProperty("is_domain")]
        public bool IsDomain { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("options")]
        public ProjectOptions Options { get; set; } = new ProjectOptions();
    }

    public class ProjectOptions
    {
    }
}