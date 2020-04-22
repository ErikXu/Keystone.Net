using System.Threading.Tasks;
using Keystone.Net.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keystone.Net.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _authenticationService;

        public AuthenticationController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet("unscoped")]
        public async Task<IActionResult> UnscopedPassword(string name, string password)
        {
            var result = await _authenticationService.UnscopedPassword(name, password);

            if (result.IsSuccessStatusCode)
            {
                return Ok(new { id = result.Body["token"]["user"]["id"].ToString() });
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        [HttpGet("scoped")]
        public async Task<IActionResult> ScopedPassword(string id, string password)
        {
            var result = await _authenticationService.ScopedPassword(id, password);

            if (result.IsSuccessStatusCode)
            {
                return Ok(new { token = result.Headers["X-Subject-Token"] });
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }
    }
}