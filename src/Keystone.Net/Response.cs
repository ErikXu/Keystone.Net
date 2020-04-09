using System.Collections.Generic;
using System.Net;

namespace Keystone.Net
{
    public class Response<TBody>
    {
        public HttpStatusCode StatusCode { get; set; }

        public TBody Body { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public bool IsSuccessStatusCode { get; set; }

        public string Message { get; set; }
    }
}