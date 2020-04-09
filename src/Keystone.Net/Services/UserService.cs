using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    public class UserService : AbstractService
    {
        public UserService(HttpClient client) : base(client)
        {
        }

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
}