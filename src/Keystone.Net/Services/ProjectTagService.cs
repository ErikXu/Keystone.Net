using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    /// <summary>
    /// https://docs.openstack.org/api-ref/identity/v3/index.html?expanded=#project-tags
    /// </summary>
    public class ProjectTagService : AbstractService
    {
        public ProjectTagService(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// List tags for a project
        /// </summary>
        public async Task<Response<JObject>> List(string token, string projectId)
        {
            var request = new Request
            {
                Uri = $"/v3/projects/{projectId}/tags",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Modify tag list for a project
        /// </summary>
        public async Task<Response<JObject>> Modify(string token, string projectId, List<string> tag)
        {
            var form = new { tag };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/projects/{projectId}/tags",
                Method = HttpMethod.Put,
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Remove all tags from a project
        /// </summary>
        public async Task<Response<JObject>> RemoveAll(string token, string projectId)
        {
            var request = new Request
            {
                Uri = $"/v3/projects/{projectId}/tags",
                Method = HttpMethod.Put,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Check if project contains tag
        /// </summary>
        public async Task<Response<JObject>> Check(string token, string projectId, string tag)
        {
            var request = new Request
            {
                Uri = $"/v3/projects/{projectId}/tags/{tag}",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Add single tag to a project
        /// </summary>
        public async Task<Response<JObject>> AddSingle(string token, string projectId, string tag)
        {
            var request = new Request
            {
                Uri = $"/v3/projects/{projectId}/tags/{tag}",
                Method = HttpMethod.Put,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        ///  Delete single tag from project
        /// </summary>
        public async Task<Response<JObject>> DeleteSingle(string token, string projectId, string tag)
        {
            var request = new Request
            {
                Uri = $"/v3/projects/{projectId}/tags/{tag}",
                Method = HttpMethod.Delete,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }
    }
}