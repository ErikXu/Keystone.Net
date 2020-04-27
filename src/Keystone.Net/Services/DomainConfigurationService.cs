using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    /// <summary>
    /// https://docs.openstack.org/api-ref/identity/v3/index.html#domain-configuration
    /// </summary>
    public class DomainConfigurationService : AbstractService
    {
        public DomainConfigurationService(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// Show default configuration settings
        /// </summary>
        public async Task<Response<JObject>> ShowDefaultConfig(string token)
        {
            var request = new Request
            {
                Uri = "/v3/domains/config/default",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Show default configuration for a group
        /// </summary>
        public async Task<Response<JObject>> ShowGroupDefaultConfig(string token, string groupId)
        {
            var request = new Request
            {
                Uri = $"/v3/domains/config/{groupId}/default",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Show default option for a group
        /// </summary>
        public async Task<Response<JObject>> ShowGroupDefaultOption(string token, string groupId, string option)
        {
            var request = new Request
            {
                Uri = $"/v3/domains/config/{groupId}/{option}/default",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Show domain group option configuration
        /// </summary>
        public async Task<Response<JObject>> ShowDomainGroupOptionConfig(string token, string domainId, string groupId, string option)
        {
            var request = new Request
            {
                Uri = $"/v3/domains/{domainId}/config/{groupId}/{option}",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Update domain group option configuration
        /// </summary>
        public async Task<Response<JObject>> UpdateDomainGroupOptionConfig(string token, string domainId, string groupId, string option, UpdateGroupOptionConfig updateGroupOptionConfig)
        {
            var form = new { updateGroupOptionConfig };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/domains/{domainId}/config/{groupId}/{option}",
                Method = new HttpMethod("PATCH"),
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Delete domain group option configuration
        /// </summary>
        public async Task<Response<JObject>> DeleteDomainGroupOptionConfig(string token, string domainId, string groupId, string option)
        {
            var request = new Request
            {
                Uri = $"/v3/domains/{domainId}/config/{groupId}/{option}",
                Method = HttpMethod.Delete,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Show domain group configuration
        /// </summary>
        public async Task<Response<JObject>> ShowDomainGroupConfig(string token, string domainId, string groupId)
        {
            var request = new Request
            {
                Uri = $"/v3/domains/{domainId}/config/{groupId}",
                Method = HttpMethod.Get,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Update domain group configuration
        /// </summary>
        public async Task<Response<JObject>> UpdateDomainGroupConfig(string token, string domainId, string groupId, UpdateDomainGroupConfig updateDomainGroupConfig)
        {
            var form = new { updateDomainGroupConfig };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/domains/{domainId}/config/{groupId}",
                Method = new HttpMethod("PATCH"),
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Delete domain group configuration
        /// </summary>
        public async Task<Response<JObject>> DeleteDomainGroupConfig(string token, string domainId, string groupId)
        {
            var request = new Request
            {
                Uri = $"/v3/domains/{domainId}/config/{groupId}",
                Method = HttpMethod.Delete,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Create domain configuration
        /// </summary>
        public async Task<Response<JObject>> CreateDomainConfig(string token, string domainId, UpdateDomainGroupConfig updateDomainGroupConfig)
        {
            var form = new { updateDomainGroupConfig };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/domains/{domainId}/config",
                Method = HttpMethod.Put,
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Show domain configuration
        /// </summary>
        public async Task<Response<JObject>> ShowDomainConfig(string token, string domainId)
        {
            var request = new Request
            {
                Uri = $"/v3/domains/{domainId}/config",
                Method = HttpMethod.Get,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Update  domain configuration
        /// </summary>
        public async Task<Response<JObject>> UpdateDomainConfig(string token, string domainId, UpdateDomainGroupConfig updateDomainGroupConfig)
        {
            var form = new { updateDomainGroupConfig };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/domains/{domainId}/config",
                Method = new HttpMethod("PATCH"),
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Delete domain configuration
        /// </summary>
        public async Task<Response<JObject>> DeleteDomainConfig(string token, string domainId)
        {
            var request = new Request
            {
                Uri = $"/v3/domains/{domainId}/config",
                Method = HttpMethod.Delete,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }
    }

    public class UpdateGroupOptionConfig
    {
        /// <summary>
        /// The option name. For the ldap group, a valid value is url or user_tree_dn. For the identity group, a valid value is driver.
        /// </summary>
        [JsonProperty("option")]
        public string Option { get; set; }

        /// <summary>
        /// The LDAP URL.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// The Identity backend driver.
        /// </summary>
        [JsonProperty("driver")]
        public string Driver { get; set; }

        /// <summary>
        /// The base distinguished name (DN) of LDAP, from where all users can be reached. For example, ou=Users,dc=root,dc=org.
        /// </summary>
        [JsonProperty("user_tree_dn")]
        public string UsertreeDn { get; set; }
    }

    public class UpdateDomainGroupConfig
    {
        /// <summary>
        /// The LDAP URL.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// The Identity backend driver.
        /// </summary>
        [JsonProperty("driver")]
        public string Driver { get; set; }

        /// <summary>
        /// An ldap object. Required to set the LDAP group configuration options.
        /// </summary>
        [JsonProperty("ldap")]
        public string Ldap { get; set; }

        /// <summary>
        /// A config object
        /// </summary>
        [JsonProperty("config")]
        public string Config { get; set; }

        /// <summary>
        /// The base distinguished name (DN) of LDAP, from where all users can be reached. For example, ou=Users,dc=root,dc=org.
        /// </summary>
        [JsonProperty("user_tree_dn")]
        public string UsertreeDn { get; set; }

        /// <summary>
        /// An identity object.
        /// </summary>
        [JsonProperty("identity")]
        public object Identity { get; set; }
    }
}