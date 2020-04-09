using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    public class GroupService : AbstractService
    {
        public GroupService(HttpClient client) : base(client)
        {
        }

        public async Task<Response<JObject>> List(string token)
        {
            var request = new Request
            {
                Uri = "/v3/groups",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }

        public async Task<Response<JObject>> Create(string token, Group group)
        {
            var template = "{\"group\":{\"description\":\"{description}\",\"domain_id\":\"{domain_id}\",\"name\":\"{name}\"}}";
            var body = template.Replace("{name}", group.Name)
                                     .Replace("{description}", group.Description)
                                     .Replace("{domain_id}", group.DomainId);

            var request = new Request
            {
                Uri = "/v3/groups",
                Method = HttpMethod.Post,
                Token = token,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }
    }

    public class Group
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string DomainId { get; set; }
    }
}