using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Services
{
    public class AuthenticationService : AbstractService
    {
        public AuthenticationService(HttpClient client) : base(client)
        {
        }

        public async Task<Response<JObject>> UnscopedPassword(string name, string password, string domain = "Default")
        {
            var auth = new Auth
            {
                Identity = new AuthIdentity
                {
                    Methods = new List<string> { AuthMethod.Password },
                    Password = new AuthPassword
                    {
                        User = new AuthUser
                        {
                            Name = name,
                            Password = password,
                            Domain = new AuthDomain
                            {
                                Name = domain
                            }
                        }
                    }
                }
            };

            var form = new { auth };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/auth/tokens",
                Method = HttpMethod.Post,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        public async Task<Response<JObject>> ExplicitUnscopedPassword(string id, string password)
        {
            var auth = new ExplicitAuth
            {
                Identity = new AuthIdentity
                {
                    Methods = new List<string> { AuthMethod.Password },
                    Password = new AuthPassword
                    {
                        User = new AuthUser
                        {
                            Id = id,
                            Password = password
                        }
                    }
                }
            };

            var form = new { auth };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/auth/tokens",
                Method = HttpMethod.Post,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        public async Task<Response<JObject>> SystemScopedPassword(string id, string password)
        {
            var auth = new Auth
            {
                Identity = new AuthIdentity
                {
                    Methods = new List<string> { AuthMethod.Password },
                    Password = new AuthPassword
                    {
                        User = new AuthUser
                        {
                            Id = id,
                            Password = password
                        }
                    }
                },
                Scope = new AuthScope
                {
                    System = new AuthScopeSystem
                    {
                        All = true
                    }
                }
            };

            var form = new { auth };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/auth/tokens",
                Method = HttpMethod.Post,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        public async Task<Response<JObject>> DomainScopedPassword(string id, string password, string domainId)
        {
            var auth = new Auth
            {
                Identity = new AuthIdentity
                {
                    Methods = new List<string> { AuthMethod.Password },
                    Password = new AuthPassword
                    {
                        User = new AuthUser
                        {
                            Id = id,
                            Password = password
                        }
                    }
                },
                Scope = new AuthScope
                {
                    Domain = new AuthScopeDomain
                    {
                        Id = domainId
                    }
                }
            };

            var form = new { auth };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/auth/tokens",
                Method = HttpMethod.Post,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        public async Task<Response<JObject>> ProjectScopedPassword(string id, string password, string projectId)
        {
            var auth = new Auth
            {
                Identity = new AuthIdentity
                {
                    Methods = new List<string> { AuthMethod.Password },
                    Password = new AuthPassword
                    {
                        User = new AuthUser
                        {
                            Id = id,
                            Password = password
                        }
                    }
                },
                Scope = new AuthScope
                {
                    Project = new AuthScopeProject
                    {
                        Id = projectId
                    }
                }
            };

            var form = new { auth };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/auth/tokens",
                Method = HttpMethod.Post,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        public async Task<Response<JObject>> ProjectScopedPassword(string id, string password, string projectName, string domainId)
        {
            var auth = new Auth
            {
                Identity = new AuthIdentity
                {
                    Methods = new List<string> { AuthMethod.Password },
                    Password = new AuthPassword
                    {
                        User = new AuthUser
                        {
                            Id = id,
                            Password = password
                        }
                    }
                },
                Scope = new AuthScope
                {
                    Project = new AuthScopeProject
                    {
                        Name = projectName,
                        Domain = new AuthScopeDomain
                        {
                            Id = domainId
                        }
                    }
                }
            };

            var form = new { auth };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/auth/tokens",
                Method = HttpMethod.Post,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        public async Task<Response<JObject>> UnscopedToken(string token)
        {
            var auth = new Auth
            {
                Identity = new AuthIdentity
                {
                    Methods = new List<string> { AuthMethod.Token },
                    Token = new AuthToken
                    {
                        Id = token
                    }
                }
            };

            var form = new { auth };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/auth/tokens",
                Method = HttpMethod.Post,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        public async Task<Response<JObject>> ExplicitUnscopedToken(string token)
        {
            var auth = new ExplicitAuth
            {
                Identity = new AuthIdentity
                {
                    Methods = new List<string> { AuthMethod.Token },
                    Token = new AuthToken
                    {
                        Id = token
                    }
                }
            };

            var form = new { auth };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/auth/tokens",
                Method = HttpMethod.Post,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        public async Task<Response<JObject>> SystemScopedToken(string token)
        {
            var auth = new Auth
            {
                Identity = new AuthIdentity
                {
                    Methods = new List<string> { AuthMethod.Token },
                    Token = new AuthToken
                    {
                        Id = token
                    }
                },
                Scope = new AuthScope
                {
                    System = new AuthScopeSystem
                    {
                        All = true
                    }
                }
            };

            var form = new { auth };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/auth/tokens",
                Method = HttpMethod.Post,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        public async Task<Response<JObject>> DomainScopedToken(string token, string domainId)
        {
            var auth = new Auth
            {
                Identity = new AuthIdentity
                {
                    Methods = new List<string> { AuthMethod.Token },
                    Token = new AuthToken
                    {
                        Id = token
                    }
                },
                Scope = new AuthScope
                {
                    Domain = new AuthScopeDomain
                    {
                        Id = domainId
                    }
                }
            };

            var form = new { auth };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/auth/tokens",
                Method = HttpMethod.Post,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        public async Task<Response<JObject>> ProjectScopedToken(string token, string projectId)
        {
            var auth = new Auth
            {
                Identity = new AuthIdentity
                {
                    Methods = new List<string> { AuthMethod.Token },
                    Token = new AuthToken
                    {
                        Id = token
                    }
                },
                Scope = new AuthScope
                {
                    Project = new AuthScopeProject
                    {
                        Id = projectId
                    }
                }
            };

            var form = new { auth };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/auth/tokens",
                Method = HttpMethod.Post,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        public async Task<Response<JObject>> ProjectScopedToken(string token, string projectName, string domainId)
        {
            var auth = new Auth
            {
                Identity = new AuthIdentity
                {
                    Methods = new List<string> { AuthMethod.Token },
                    Token = new AuthToken
                    {
                        Id = token
                    }
                },
                Scope = new AuthScope
                {
                    Project = new AuthScopeProject
                    {
                        Name = projectName,
                        Domain = new AuthScopeDomain
                        {
                            Id = domainId
                        }
                    }
                }
            };

            var form = new { auth };
            var body = Serialize(form);

            var request = new Request
            {
                Uri = "/v3/auth/tokens",
                Method = HttpMethod.Post,
                Body = body
            };

            return await ExecuteAsync<JObject>(request);
        }

        public async Task<Response<JObject>> ValidateToken(string token, string targetToken)
        {
            var request = new Request
            {
                Uri = "/v3/auth/tokens",
                Method = HttpMethod.Get,
                Token = token,
                TargetToken = targetToken
            };

            return await ExecuteAsync<JObject>(request);
        }

        public async Task<Response<JObject>> CheckToken(string token, string targetToken)
        {
            var request = new Request
            {
                Uri = "/v3/auth/tokens",
                Method = HttpMethod.Head,
                Token = token,
                TargetToken = targetToken
            };

            return await ExecuteAsync<JObject>(request);
        }

        public async Task<Response<JObject>> DeleteToken(string token, string targetToken)
        {
            var request = new Request
            {
                Uri = "/v3/auth/tokens",
                Method = HttpMethod.Delete,
                Token = token,
                TargetToken = targetToken
            };

            return await ExecuteAsync<JObject>(request);
        }

        public async Task<Response<JObject>> GetServiceCatalog(string token)
        {
            var request = new Request
            {
                Uri = "/v3/auth/catalog",
                Method = HttpMethod.Get,
                Token = token
            };

            return await ExecuteAsync<JObject>(request);
        }
    }

    public class AuthMethod
    {
        public static string Password => "password";

        public static string Token => "token";
    }

    public class Auth
    {
        [JsonProperty("identity")]
        public AuthIdentity Identity { get; set; }

        [JsonProperty("scope")]
        public AuthScope Scope { get; set; }
    }

    public class ExplicitAuth
    {
        [JsonProperty("identity")]
        public AuthIdentity Identity { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; } = "unscoped";
    }

    public class AuthIdentity
    {
        [JsonProperty("methods")]
        public List<string> Methods { get; set; }

        [JsonProperty("password")]
        public AuthPassword Password { get; set; }

        [JsonProperty("token")]
        public AuthToken Token { get; set; }
    }

    public class AuthToken
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class AuthPassword
    {
        [JsonProperty("user")]
        public AuthUser User { get; set; }
    }

    public class AuthUser
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("domain")]
        public AuthDomain Domain { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }

    public class AuthDomain
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }


    public class AuthScope
    {
        [JsonProperty("system")]
        public AuthScopeSystem System { get; set; }

        [JsonProperty("domain")]
        public AuthScopeDomain Domain { get; set; }

        [JsonProperty("project")]
        public AuthScopeProject Project { get; set; }
    }

    public class AuthScopeSystem
    {
        [JsonProperty("all")]
        public bool All { get; set; }
    }

    public class AuthScopeDomain
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class AuthScopeProject
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("domain")]
        public AuthScopeDomain Domain { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}