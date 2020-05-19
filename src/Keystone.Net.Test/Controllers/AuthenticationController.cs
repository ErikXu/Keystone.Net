using System.Threading.Tasks;
using Keystone.Net.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Keystone.Net.Test.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;
        private readonly string _subjectTokenKey;

        public AuthenticationController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _subjectTokenKey = "X-Subject-Token";
        }

        [HttpGet("unscoped/password")]
        public async Task<IActionResult> UnscopedPassword(string name, string password, string domain = "Default")
        {
            var result = await _authenticationService.UnscopedPassword(name, password, domain);

            if (result.IsSuccessStatusCode)
            {
                return Ok(new { id = result.Body["token"]["user"]["id"].ToString(), token = result.Headers[_subjectTokenKey] });
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        [HttpGet("explicit-unscoped/password")]
        public async Task<IActionResult> ExplicitUnscopedPassword(string id, string password)
        {
            var result = await _authenticationService.ExplicitUnscopedPassword(id, password);

            if (result.IsSuccessStatusCode)
            {
                return Ok(new { token = result.Headers[_subjectTokenKey] });
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        [HttpGet("system-scoped/password")]
        public async Task<IActionResult> SystemScopedPassword(string id, string password)
        {
            var result = await _authenticationService.SystemScopedPassword(id, password);

            if (result.IsSuccessStatusCode)
            {
                return Ok(new { token = result.Headers[_subjectTokenKey] });
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        [HttpGet("domain-scoped/password")]
        public async Task<IActionResult> DomainScopedPassword(string id, string password, string domainId = "default")
        {
            var result = await _authenticationService.DomainScopedPassword(id, password, domainId);

            if (result.IsSuccessStatusCode)
            {
                return Ok(new { token = result.Headers[_subjectTokenKey] });
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        /// <summary>
        /// Use project id, or domain id and project name to indicate a project
        /// </summary>
        /// <returns></returns>
        [HttpGet("project-scoped/password")]
        public async Task<IActionResult> ProjectScopedPassword(string id, string password, string projectId, string projectName, string domainId)
        {
            Response<JObject> result;

            if (!string.IsNullOrWhiteSpace(projectId))
            {
                result = await _authenticationService.ProjectScopedPassword(id, password, projectId);
            }
            else
            {
                result = await _authenticationService.ProjectScopedPassword(id, password, projectName, domainId);
            }

            if (result.IsSuccessStatusCode)
            {
                return Ok(new { token = result.Headers[_subjectTokenKey] });
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        [HttpGet("unscoped/token")]
        public async Task<IActionResult> UnscopedToken(string token)
        {
            var result = await _authenticationService.UnscopedToken(token);

            if (result.IsSuccessStatusCode)
            {
                return Ok(new { token = result.Headers[_subjectTokenKey] });
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        [HttpGet("explicit-unscoped/token")]
        public async Task<IActionResult> ExplicitUnscopedToken(string token)
        {
            var result = await _authenticationService.ExplicitUnscopedToken(token);

            if (result.IsSuccessStatusCode)
            {
                return Ok(new { token = result.Headers[_subjectTokenKey] });
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        [HttpGet("system-scoped/token")]
        public async Task<IActionResult> SystemScopedToken(string token)
        {
            var result = await _authenticationService.SystemScopedToken(token);

            if (result.IsSuccessStatusCode)
            {
                return Ok(new { token = result.Headers[_subjectTokenKey] });
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        [HttpGet("domain-scoped/token")]
        public async Task<IActionResult> DomainScopedToken(string token, string domainId = "default")
        {
            var result = await _authenticationService.DomainScopedToken(token, domainId);

            if (result.IsSuccessStatusCode)
            {
                return Ok(new { token = result.Headers[_subjectTokenKey] });
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        /// <summary>
        /// Use project id, or domain id and project name to indicate a project
        /// </summary>
        /// <returns></returns>
        [HttpGet("project-scoped/token")]
        public async Task<IActionResult> ProjectScopedToken(string token, string projectId, string projectName, string domainId)
        {
            Response<JObject> result;

            if (!string.IsNullOrWhiteSpace(projectId))
            {
                result = await _authenticationService.ProjectScopedToken(token, projectId);
            }
            else
            {
                result = await _authenticationService.ProjectScopedToken(token, projectName, domainId);
            }

            if (result.IsSuccessStatusCode)
            {
                return Ok(new { token = result.Headers[_subjectTokenKey] });
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        [HttpGet("token")]
        public async Task<IActionResult> ValidateToken(string token, string targetToken)
        {
            var result = await _authenticationService.ValidateToken(token, targetToken);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        [HttpHead("token")]
        public async Task<IActionResult> CheckToken(string token, string targetToken)
        {
            var result = await _authenticationService.CheckToken(token, targetToken);

            if (result.IsSuccessStatusCode)
            {
                return Ok();
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        [HttpDelete("token")]
        public async Task<IActionResult> DeleteToken(string token, string targetToken)
        {
            var result = await _authenticationService.DeleteToken(token, targetToken);

            if (result.IsSuccessStatusCode)
            {
                return Ok();
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        [HttpGet("catalog")]
        public async Task<IActionResult> GetServiceCatalog(string token)
        {
            var result = await _authenticationService.GetServiceCatalog(token);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        [HttpGet("projects")]
        public async Task<IActionResult> GetProjectScopes(string token)
        {
            var result = await _authenticationService.GetProjectScopes(token);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        [HttpGet("domains")]
        public async Task<IActionResult> GetDomainScopes(string token)
        {
            var result = await _authenticationService.GetDomainScopes(token);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        [HttpGet("system")]
        public async Task<IActionResult> GetSystemScopes(string token)
        {
            var result = await _authenticationService.GetSystemScopes(token);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }
    }
}