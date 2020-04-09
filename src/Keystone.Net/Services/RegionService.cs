using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    public class RegionService : AbstractService
    {
        public RegionService(HttpClient client) : base(client)
        {
        }

        public async Task<Response<JObject>> List(string token)
        {
            var request = new Request
            {
                Uri = "/v3/regions",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }
    }
}