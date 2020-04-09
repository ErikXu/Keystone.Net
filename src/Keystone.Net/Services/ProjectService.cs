using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    public class ProjectService : AbstractService
    {
        public ProjectService(HttpClient client) : base(client)
        {
        }

        public async Task<Response<JObject>> List(string token)
        {
            var request = new Request
            {
                Uri = "/v3/projects",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

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