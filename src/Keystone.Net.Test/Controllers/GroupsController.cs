using System.Threading.Tasks;
using Keystone.Net.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keystone.Net.Test.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly GroupService _groupService;

        public GroupsController(GroupService groupService)
        {
            _groupService = groupService;
        }

        /// <summary>
        /// List groups
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> List(string token, string domainId)
        {
            var result = await _groupService.List(token, domainId);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }
    }
}