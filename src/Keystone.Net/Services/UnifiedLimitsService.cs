using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    /// <summary>
    /// https://docs.openstack.org/api-ref/identity/v3/index.html#unified-limits
    /// </summary>
    public class UnifiedLimitsService : AbstractService
    {
        public UnifiedLimitsService(HttpClient client) : base(client)
        {
        }

        /// <summary>
        /// List Registered Limits
        /// </summary>
        public async Task<Response<JObject>> List(string token)
        {
            var request = new Request
            {
                Uri = "/v3/registered_limits",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Create Registered Limits
        /// </summary>
        public async Task<Response<JObject>> Create(string token, RegisteredLimitArray registeredLimit)
        {
            var form = new { user = registeredLimit };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/registered_limits",
                Method = HttpMethod.Post,
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Update Registered Limits
        /// </summary>
        public async Task<Response<JObject>> Update(string token, string id, RegisteredLimitData registeredLimit)
        {
            var form = new { user = registeredLimit };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/registered_limits/{id}",
                Method = new HttpMethod("PATCH"),
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Show Registered Limit Details
        /// </summary>
        public async Task<Response<JObject>> Details(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/registered_limits/{id}",
                Method = HttpMethod.Get,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Delete Registered Limit Details
        /// </summary>
        public async Task<Response<JObject>> Delete(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/registered_limits/{id}",
                Method = HttpMethod.Delete,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Get Enforcement Model
        /// </summary>
        public async Task<Response<JObject>> GetEnforcementModel(string token)
        {
            var request = new Request
            {
                Uri = "/v3/limits/model",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// List Limits
        /// </summary>
        public async Task<Response<JObject>> ListLimits(string token)
        {
            var request = new Request
            {
                Uri = "/v3/limits",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Create Limits
        /// </summary>
        public async Task<Response<JObject>> CreateLimits(string token, LimitArray limits)
        {
            var form = new { user = limits };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/limits",
                Method = HttpMethod.Post,
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Update Limits
        /// </summary>
        public async Task<Response<JObject>> UpdateLimits(string token, string id, ChangeLimit limit)
        {
            var form = new { user = limit };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = $"/v3/limits/{id}",
                Method = new HttpMethod("PATCH"),
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Show Limit Details
        /// </summary>
        public async Task<Response<JObject>> DetailsLimits(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/limits/{id}",
                Method = HttpMethod.Get,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }

        /// <summary>
        /// Delete Registered Limit
        /// </summary>
        public async Task<Response<JObject>> DeleteLimits(string token, string id)
        {
            var request = new Request
            {
                Uri = $"/v3/limits/{id}",
                Method = HttpMethod.Delete,
                Token = token,
            };

            return await ExecuteAsync<JObject>(request);
        }
    }

    public class RegisteredLimit
    {
        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        [JsonProperty("region_id")]
        public string RegionId { get; set; }

        [JsonProperty("resource_name")]
        public string ResourceName { get; set; }

        [JsonProperty("default_limit")]
        public int DefaultLimit { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class RegisteredLimitArray
    {
        [JsonProperty("registered_limits")]
        public List<RegisteredLimit> RegisteredLimits { get; set; }
    }

    public class RegisteredLimitData
    {
        [JsonProperty("registered_limit")]
        public RegisteredLimit RegisteredLimit { get; set; }
    }

    public class Limit
    {
        [JsonProperty("service_id")]
        public string ServiceId { get; set; }

        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        [JsonProperty("region_id")]
        public string RegionId { get; set; }

        [JsonProperty("resource_name")]
        public string ResourceName { get; set; }

        [JsonProperty("resource_limit")]
        public int ResourceLimit { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class LimitArray
    {
        [JsonProperty("limits")]
        public List<Limit> Limits { get; set; }
    }

    public class LimitData
    {
        [JsonProperty("resource_limit")]
        public int ResourceLimit { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class ChangeLimit
    {
        [JsonProperty("limit")]
        public LimitData Limit { get; set; }
    }
}