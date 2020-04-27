using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    /// <summary>
    /// https://docs.openstack.org/api-ref/identity/v3/index.html#os-inherit
    /// </summary>
    public class OsInheritService : AbstractService
    {
        public OsInheritService(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// Assign role to user on projects owned by domain
        /// </summary>
        public async Task<Response<JObject>> AssignRoleToUser(string token, string domainId, string userId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/OS-INHERIT/domains/{domainId}/users/{userId}/roles/{roleId}/inherited_to_projects",
                Method = HttpMethod.Put,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Assign role to group on projects owned by a domain
        /// </summary>
        public async Task<Response<JObject>> AssignRoleToGroup(string token, string domainId, string groupId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/OS-INHERIT/domains/{domainId}/groups/{groupId}/roles/{roleId}/inherited_to_projects",
                Method = HttpMethod.Put,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// List user’s inherited project roles on a domain
        /// </summary>
        public async Task<Response<JObject>> ListUserDomain(string token, string domainId, string userId)
        {
            var request = new Request
            {
                Uri = $"/v3/OS-INHERIT/domains/{domainId}/users/{userId}/roles/inherited_to_projects",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// List group’s inherited project roles on domain
        /// </summary>
        public async Task<Response<JObject>> ListGroupDomain(string token, string domainId, string groupId)
        {
            var request = new Request
            {
                Uri = $"/v3/OS-INHERIT/domains/{domainId}/groups/{groupId}/roles/inherited_to_projects",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Check if user has an inherited project role on domain
        /// </summary>
        public async Task<Response<JObject>> CheckUserDomainHasInherited(string token, string domainId, string userId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/OS-INHERIT/domains/{domainId}/users/{userId}/roles/{roleId}/inherited_to_projects",
                Method = HttpMethod.Head,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Check if group has an inherited project role on domain
        /// </summary>
        public async Task<Response<JObject>> CheckGroupDomainHasInherited(string token, string domainId, string groupId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/OS-INHERIT/domains/{domainId}/groups/{groupId}/roles/{roleId}/inherited_to_projects",
                Method = HttpMethod.Head,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Revoke an inherited project role from user on domain
        /// </summary>
        public async Task<Response<JObject>> DeleteUserDomainHasInherited(string token, string domainId, string userId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/OS-INHERIT/domains/{domainId}/users/{userId}/roles/{roleId}/inherited_to_projects",
                Method = HttpMethod.Delete,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Revoke an inherited project role from group on domain
        /// </summary>
        public async Task<Response<JObject>> DeleteGroupDomainHasInherited(string token, string domainId, string groupId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/OS-INHERIT/domains/{domainId}/groups/{groupId}/roles/{roleId}/inherited_to_projects",
                Method = HttpMethod.Delete,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        ///  Assign role to user on projects in a subtree
        /// </summary>
        public async Task<Response<JObject>> AssignRoleUserToProjects(string token, string projectId, string userId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/OS-INHERIT/projects/{projectId}/users/{userId}/roles/{roleId}/inherited_to_projects",
                Method = HttpMethod.Put,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Assign role to group on projects in a subtree
        /// </summary>
        public async Task<Response<JObject>> AssignRoleGroupToProjects(string token, string projectId, string groupId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/OS-INHERIT/projects/{projectId}/groups/{groupId}/roles/{roleId}/inherited_to_projects",
                Method = HttpMethod.Put,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Check if user has an inherited project role on project
        /// </summary>
        public async Task<Response<JObject>> CheckRoleUserToProjects(string token, string projectId, string userId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/OS-INHERIT/projects/{projectId}/users/{userId}/roles/{roleId}/inherited_to_projects",
                Method = HttpMethod.Head,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Check if group has an inherited project role on project
        /// </summary>
        public async Task<Response<JObject>> CheckRoleGroupToProjects(string token, string projectId, string groupId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/OS-INHERIT/projects/{projectId}/groups/{groupId}/roles/{roleId}/inherited_to_projects",
                Method = HttpMethod.Head,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Revoke an inherited project role from user on project
        /// </summary>
        public async Task<Response<JObject>> DeleteRoleUserToProjects(string token, string projectId, string userId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/OS-INHERIT/projects/{projectId}/users/{userId}/roles/{roleId}/inherited_to_projects",
                Method = HttpMethod.Delete,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Revoke an inherited project role from group on project
        /// </summary>
        public async Task<Response<JObject>> DeleteRoleGroupToProjects(string token, string projectId, string groupId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/OS-INHERIT/projects/{projectId}/groups/{groupId}/roles/{roleId}/inherited_to_projects",
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
    }
}