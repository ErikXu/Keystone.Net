using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    public class AuthenticationService: AbstractService
    {
        public AuthenticationService(HttpClient client) : base(client)
        {
        }

        public async Task<Response<JObject>> UnscopedPassword(string name, string password, string domain = "Default")
        {
            var template = "{\"auth\":{\"identity\":{\"methods\":[\"password\"],\"password\":{\"user\":{\"name\":\"{name}\",\"domain\":{\"name\":\"{domain}\"},\"password\":\"{password}\"}}}}}";
            var body = template.Replace("{name}", name)
                                     .Replace("{password}", password)
                                     .Replace("{domain}", domain);

            var request = new Request
            {
                Uri = "/v3/auth/tokens",
                Method = HttpMethod.Post,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        public async Task<Response<JObject>> ScopedPassword(string id, string password)
        {
            var template = "{\"auth\":{\"identity\":{\"methods\":[\"password\"],\"password\":{\"user\":{\"id\":\"{id}\",\"password\":\"{password}\"}}},\"scope\":{\"system\":{\"all\":true}}}}";
            var body = template.Replace("{id}", id)
                                     .Replace("{password}", password);

            var request = new Request
            {
                Uri = "/v3/auth/tokens",
                Method = HttpMethod.Post,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }
    }
}