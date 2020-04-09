using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    public class DomainService : AbstractService
    {
        public DomainService(HttpClient client) : base(client)
        {
        }

        public async Task<Response<JObject>> List(string token)
        {
            var request = new Request
            {
                Uri = "/v3/domains",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }
    }
}