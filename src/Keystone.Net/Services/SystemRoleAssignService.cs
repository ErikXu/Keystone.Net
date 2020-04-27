using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    public class SystemRoleAssignService : AbstractService
    {
        public SystemRoleAssignService(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// List system role assignments for a user
        /// </summary>
        public async Task<Response<JObject>> List(string token, string useId)
        {
            var request = new Request
            {
                Uri = $"/v3/system/users/{useId}/roles",
                Method = HttpMethod.Get,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Assign a system role to a user
        /// </summary>
        public async Task<Response<JObject>> AssignRoleToUser(string token, string useId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/system/users/{useId}/roles/{roleId}",
                Method = HttpMethod.Put,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Check user for a system role assignment
        /// </summary>
        public async Task<Response<JObject>> CheckRoleToUser(string token, string useId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/system/users/{useId}/roles/{roleId}",
                Method = HttpMethod.Head,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Get system role assignment for a user
        /// </summary>
        public async Task<Response<JObject>> GetRoleToUser(string token, string useId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/system/users/{useId}/roles/{roleId}",
                Method = HttpMethod.Get,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Delete a system role assignment from a user
        /// </summary>
        public async Task<Response<JObject>> DeleteRoleToUser(string token, string useId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/system/users/{useId}/roles/{roleId}",
                Method = HttpMethod.Delete,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// List system role assignments for a group
        /// </summary>
        public async Task<Response<JObject>> ListRoleToGroup(string token, string groupId)
        {
            var request = new Request
            {
                Uri = $"/v3/system/groups/{groupId}/roles",
                Method = HttpMethod.Get,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Assign a system role to a group
        /// </summary>
        public async Task<Response<JObject>> AssignRoleToGroup(string token, string groupId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/system/groups/{groupId}/roles/{roleId}",
                Method = HttpMethod.Put,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Check group for a system role assignment
        /// </summary>
        public async Task<Response<JObject>> CheckRoleToGroup(string token, string groupId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/system/groups/{groupId}/roles/{roleId}",
                Method = HttpMethod.Head,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Get system role assignment for a group
        /// </summary>
        public async Task<Response<JObject>> GetRoleToGroup(string token, string groupId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/system/groups/{groupId}/roles/{roleId}",
                Method = HttpMethod.Get,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        ///  Delete a system role assignment from a group
        /// </summary>
        public async Task<Response<JObject>> DeleteRoleToGroup(string token, string groupId, string roleId)
        {
            var request = new Request
            {
                Uri = $"/v3/system/groups/{groupId}/roles/{roleId}",
                Method = HttpMethod.Delete,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }
    }
}