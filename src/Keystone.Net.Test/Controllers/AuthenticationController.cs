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

        [HttpGet]
        public async Task<IActionResult> UnscopedPassword()
        {
            var result = await _authenticationService.UnscopedPassword("admin", "admin");

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body["token"]["user"]["id"].ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }
    }
}