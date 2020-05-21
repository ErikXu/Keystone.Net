using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    /// <summary>
    /// https://docs.openstack.org/api-ref/identity/v3/index.html#groups
    /// </summary>
    public class GroupService : AbstractService
    {
        public GroupService(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// List groups
        /// </summary>
        public async Task<Response<GroupListResult>> List(string token, string domainId)
        {
            var request = new Request
            {
                Uri = "/v3/groups",
                Method = HttpMethod.Get,
                Token = token
            };

            request.AddQuery("domain_id", domainId);

            return await ExecuteAsync<GroupListResult>(request);
        }

        /// <summary>
        /// Create group
        /// </summary>
        public async Task<Response<JObject>> Create(string token, Group group)
        {
            var template = "{\"group\":{\"description\":\"{description}\",\"domain_id\":\"{domain_id}\",\"name\":\"{name}\"}}";
            var body = template.Replace("{name}", group.Name)
                                     .Replace("{description}", group.Description)
                                     .Replace("{domain_id}", group.DomainId);

            var request = new Request
            {
                Uri = "/v3/groups",
                Method = HttpMethod.Post,
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Show group details
        /// </summary>
        public async Task<Response<JObject>> Details(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/groups/{id}",
                Method = HttpMethod.Get,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Update group
        /// </summary>
        public async Task<Response<JObject>> Update(string token, string id, Group group)
        {
            var form = new { group };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/groups/{id}",
                Method = new HttpMethod("PATCH"),
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Delete group
        /// </summary>
        public async Task<Response<JObject>> Delete(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/groups/{id}",
                Method = HttpMethod.Delete,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// List users in group
        /// </summary>
        public async Task<Response<JObject>> ListUsersInGroup(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/groups/{id}/users",
                Method = HttpMethod.Get,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Add user to group
        /// </summary>
        public async Task<Response<JObject>> AddUserToGroup(string token, string id, string userId)
        {
            var request = new Request
            {
                Uri = $"/v3/groups/{id}/users/{userId}",
                Method = HttpMethod.Put,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Check whether user belongs to group
        /// </summary>
        public async Task<Response<JObject>> CheckUserInGroup(string token, string id, string userId)
        {
            var request = new Request
            {
                Uri = $"/v3/groups/{id}/users/{userId}",
                Method = HttpMethod.Head,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Remove user from group
        /// </summary>
        public async Task<Response<JObject>> RemoveUserFromGroup(string token, string id, string userId)
        {
            var request = new Request
            {
                Uri = $"/v3/groups/{id}/users/{userId}",
                Method = HttpMethod.Delete,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }
    }

    public class Group
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("domainId")]
        public string DomainId { get; set; }
    }


    public class GroupListResult
    {
        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("groups")]
        public List<GroupListItem> Groups { get; set; }
    }


    public class GroupListItem
    {
        [JsonProperty("domain_id")]
        public string DomainId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}