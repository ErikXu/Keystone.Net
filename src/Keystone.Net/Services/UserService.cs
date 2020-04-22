using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    /// <summary>
    /// https://docs.openstack.org/api-ref/identity/v3/index.html?expanded=#users
    /// </summary>
    public class UserService : AbstractService
    {
        public UserService(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// List users
        /// </summary>
        public async Task<Response<JObject>> List(string token)
        {
            var request = new Request
            {
                Uri = "/v3/users",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Create user
        /// </summary>
        public async Task<Response<JObject>> Create(string token, User user)
        {
            var form = new { user };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/users",
                Method = HttpMethod.Post,
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Show user details
        /// </summary>
        public async Task<Response<JObject>> Details(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/users/{id}",
                Method = HttpMethod.Get,
                Token = token
            };
            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Update user
        /// </summary>
        public async Task<Response<JObject>> Update(string token, string id, UpdateUser user)
        {
            var form = new { user };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/users/{id}",
                Method = new HttpMethod("PATCH"),
                Token = token,
                Body = body
            };
            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Delete user
        /// </summary>
        public async Task<Response<JObject>> Delete(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/users/{id}",
                Method = HttpMethod.Delete,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// List groups to which a user belongs
        /// </summary>
        public async Task<Response<JObject>> ListGroups(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/users/{id}/groups",
                Method = HttpMethod.Get,
                Token = token
            };
            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// List projects for user
        /// </summary>
        public async Task<Response<JObject>> ListProjects(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/users/{id}/projects",
                Method = HttpMethod.Get,
                Token = token
            };
            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Change password for user
        /// </summary>
        public async Task<Response<JObject>> ChangePassword(string id, ChangePassword changePassword)
        {
            var form = new { user = changePassword };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/users/{id}/password",
                Method = HttpMethod.Post,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }
    }

    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("default_project_id")]
        public string DefaultProjectId { get; set; }

        [JsonProperty("domain_id")]
        public string DomainId { get; set; } = string.Empty;

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("options")]
        public UseOptions Options { get; set; } = new UseOptions();
    }

    public class UseOptions
    {
        [JsonProperty("ignore_change_password_upon_first_use")]
        public bool? IgnoreChangePasswordUponFirstUse { get; set; }

        [JsonProperty("ignore_password_expiry")]
        public bool? IgnorePasswordExpiry { get; set; }

        [JsonProperty("ignore_lockout_failure_attempts")]
        public bool? IgnoreLockoutFailureAttempts { get; set; }

        [JsonProperty("lock_password")]
        public bool? LockPassword { get; set; }

        [JsonProperty("multi_factor_auth_enabled")]
        public bool? MultiFactorAuthEnabled { get; set; }

        [JsonProperty("multi_factor_auth_rules")]
        public List<string> MultiFactorAuthRules { get; set; }
    }

    public class UpdateUser
    {
        [JsonProperty("default_project_id")]
        public string DefaultProjectId { get; set; }

        [JsonProperty("domain_id")]
        public string DomainId { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("federated")]
        public List<Federated> Federated { get; set; } = new List<Federated>();

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("options")]
        public UseOptions Options { get; set; } = new UseOptions();
    }

    public class Federated
    {
        [JsonProperty("idp_id")]
        public string IdPid { get; set; }

        [JsonProperty("protocols")]
        public List<Protocols> Protocols { get; set; }
    }

    public class Protocols
    {
        [JsonProperty("protocol_id")]
        public string ProtocolId { get; set; }

        [JsonProperty("unique_id")]
        public string UniqueId { get; set; }
    }

    public class ChangePassword
    {
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("original_password")]
        public string OriginalPassword { get; set; }
    }
}