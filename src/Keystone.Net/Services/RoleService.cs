using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    /// <summary>
    /// https://docs.openstack.org/api-ref/identity/v3/index.html#roles
    /// </summary>
    public class RoleService : AbstractService
    {
        public RoleService(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// List roles
        /// </summary>
        public async Task<Response<RoleListResult>> List(string token, string domainId)
        {
            var request = new Request
            {
                Uri = "/v3/roles",
                Method = HttpMethod.Get,
                Token = token
            };

            request.AddQuery("domain_id", domainId);

            return await ExecuteAsync<RoleListResult>(request);
        }

        /// <summary>
        /// Create role
        /// </summary>
        public async Task<Response<JObject>> Create(string token, Role role)
        {
            var form = new { role };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/roles",
                Method = HttpMethod.Post,
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Show role details
        /// </summary>
        public async Task<Response<JObject>> Details(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/roles/{id}",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Update role
        /// </summary>
        public async Task<Response<JObject>> Update(string token, string id, Role role)
        {
            var form = new { role };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/roles/{id}",
                Method = new HttpMethod("PATCH"),
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Delete role
        /// </summary>
        public async Task<Response<JObject>> Delete(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/roles/{id}",
                Method = HttpMethod.Delete,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// List role assignments for group on domain
        /// </summary>
        public async Task<Response<JObject>> ListRoleForGroupOnDomain(string token, string domainId, string groupId)
        {
            var request = new Request
            {
                Uri = $"/v3/domains/{domainId}/groups/{groupId}/roles",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Assign role to group on domain
        /// </summary>
        public async Task<Response<JObject>> AssignRoleToGroupOnDomain(string token, string domainId, string groupId, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/domains/{domainId}/groups/{groupId}/roles/{id}",
                Method = HttpMethod.Put,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Check whether group has role assignment on domain
        /// </summary>
        public async Task<Response<JObject>> CheckRoleForGroupOnDomain(string token, string domainId, string groupId, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/domains/{domainId}/groups/{groupId}/roles/{id}",
                Method = HttpMethod.Head,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Unassign role from group on domain
        /// </summary>
        public async Task<Response<JObject>> UnassignRoleFromGroupOnDomain(string token, string domainId, string groupId, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/domains/{domainId}/groups/{groupId}/roles/{id}",
                Method = HttpMethod.Delete,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// List role assignments for user on domain
        /// </summary>
        public async Task<Response<JObject>> ListRoleForUserOnDomain(string token, string domainId, string userId)
        {
            var request = new Request
            {
                Uri = $"/v3/domains/{domainId}/users/{userId}/roles",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Assign role to user on domain
        /// </summary>
        public async Task<Response<JObject>> AssignRoleToUserOnDomain(string token, string domainId, string userId, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/domains/{domainId}/users/{userId}/roles/{id}",
                Method = HttpMethod.Put,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Check whether user has role assignment on domain
        /// </summary>
        public async Task<Response<JObject>> CheckRoleForUserOnDomain(string token, string domainId, string userId, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/domains/{domainId}/users/{userId}/roles/{id}",
                Method = HttpMethod.Head,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Unassigns role from user on domain
        /// </summary>
        public async Task<Response<JObject>> UnassignsRoleFromUserOnDomain(string token, string domainId, string userId, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/domains/{domainId}/users/{userId}/roles/{id}",
                Method = HttpMethod.Delete,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// List role assignments for group on project
        /// </summary>
        public async Task<Response<JObject>> ListRoleForGroupOnProject(string token, string projectId, string groupId)
        {
            var request = new Request
            {
                Uri = $"/v3/projects/{projectId}/groups/{groupId}/roles",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Assign role to group on project
        /// </summary>
        public async Task<Response<JObject>> AssignRoleToGroupOnProject(string token, string projectId, string groupId, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/projects/{projectId}/groups/{groupId}/roles/{id}",
                Method = HttpMethod.Put,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Check whether group has role assignment on project
        /// </summary>
        public async Task<Response<JObject>> CheckRoleForGroupOnProject(string token, string projectId, string groupId, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/projects/{projectId}/groups/{groupId}/roles/{id}",
                Method = HttpMethod.Head,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Unassign role from group on project
        /// </summary>
        public async Task<Response<JObject>> UnassignRoleFromGroupOnProject(string token, string projectId, string groupId, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/projects/{projectId}/groups/{groupId}/roles/{id}",
                Method = HttpMethod.Delete,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// List role assignments for user on project
        /// </summary>
        public async Task<Response<JObject>> ListRoleForUserOnProject(string token, string projectId, string userId)
        {
            var request = new Request
            {
                Uri = $"/v3/projects/{projectId}/users/{userId}/roles",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Assign role to user on project
        /// </summary>

        public async Task<Response<JObject>> AssignRoleToUserOnProject(string token, string projectId, string userId, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/projects/{projectId}/users/{userId}/roles/{id}",
                Method = HttpMethod.Put,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Check whether user has role assignment on project
        /// </summary>
        public async Task<Response<JObject>> CheckRoleForUserOnProject(string token, string projectId, string userId, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/projects/{projectId}/users/{userId}/roles/{id}",
                Method = HttpMethod.Head,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Unassign role from user on project
        /// </summary>
        public async Task<Response<JObject>> UnassignRoleFromUserOnProject(string token, string projectId, string userId, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/projects/{projectId}/users/{userId}/roles/{id}",
                Method = HttpMethod.Delete,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// List implied (inference) roles for role
        /// </summary>
        public async Task<Response<JObject>> ListImpliedRoles(string token, string priorRoleId)
        {
            var request = new Request
            {
                Uri = $"/v3/roles/{priorRoleId}/implies",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Create role inference rule
        /// </summary>
        public async Task<Response<JObject>> CreateImpliedRule(string token, string priorRoleId, string impliesRoleId)
        {
            var request = new Request
            {
                Uri = $"/v3/roles/{priorRoleId}/implies/{impliesRoleId}",
                Method = HttpMethod.Put,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Get role inference rule
        /// </summary>

        public async Task<Response<JObject>> GetImpliedRule(string token, string priorRoleId, string impliesRoleId)
        {
            var request = new Request
            {
                Uri = $"/v3/roles/{priorRoleId}/implies/{impliesRoleId}",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Confirm role inference rule
        /// </summary>

        public async Task<Response<JObject>> ConfirmImpliedRule(string token, string priorRoleId, string impliesRoleId)
        {
            var request = new Request
            {
                Uri = $"/v3/roles/{priorRoleId}/implies/{impliesRoleId}",
                Method = HttpMethod.Head,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Delete role inference rule
        /// </summary>
        public async Task<Response<JObject>> DeleteImpliedRule(string token, string priorRoleId, string impliesRoleId)
        {
            var request = new Request
            {
                Uri = $"/v3/roles/{priorRoleId}/implies/{impliesRoleId}",
                Method = HttpMethod.Delete,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// List role assignments
        /// </summary>
        public async Task<Response<JObject>> ListRoleAssignments(string token)
        {
            var request = new Request
            {
                Uri = $"/v3/role_assignments",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// List all role inference rules
        /// </summary>
        public async Task<Response<JObject>> ListRoleInferenceRules(string token)
        {
            var request = new Request
            {
                Uri = $"/v3/role_inferences",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }
    }

    public class Role
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("domain_id")]
        public string DomainId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("options")]
        public RolesOptions Options { get; set; } = new RolesOptions();
    }

    public class RolesOptions { }


    public class RoleListResult
    {
        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("roles")]
        public List<RoleListItem> Roles { get; set; }
    }

    public class RoleListItem
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("domain_id")]
        public object DomainId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("options")]
        public object Options { get; set; }
    }
}