using System.Collections.Generic;
using System.Net.Http;

namespace Keystone.Net
{
    public class Request
    {
        public Request()
        {
            Queries = new Dictionary<string, string>();
        }

        public string Uri { get; set; }

        public string Token { get; set; }

        public string TargetToken { get; set; }

        public HttpMethod Method { get; set; }

        public string Body { get; set; } = string.Empty;

        public Dictionary<string, string> Queries { get; }

        public void AddQuery(string key, string value)
        {
            Queries[key] = value;
        }
    }
}