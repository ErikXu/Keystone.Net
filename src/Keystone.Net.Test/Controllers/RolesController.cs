using System.Threading.Tasks;
using Keystone.Net.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keystone.Net.Test.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RolesController(RoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// List roles
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> List(string token, string domainId)
        {
            var result = await _roleService.List(token, domainId);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body);
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }
    }
}