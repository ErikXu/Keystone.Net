using System.Threading.Tasks;
using Keystone.Net.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keystone.Net.Test.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// List users
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> List(string token, string domainId)
        {
            var result = await _userService.List(token, domainId);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        /// <summary>
        /// Create user
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(string token, User user)
        {
            var result = await _userService.Create(token, user);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        /// <summary>
        /// Show user details
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(string token, string id)
        {
            var result = await _userService.Details(token, id);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        /// <summary>
        /// Update user
        /// </summary>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(string token, string id, UpdateUser user)
        {
            var result = await _userService.Update(token, id, user);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        /// <summary>
        /// Delete user
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string token, string id)
        {
            var result = await _userService.Delete(token, id);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        /// <summary>
        /// List groups to which a user belongs
        /// </summary>
        [HttpGet("{id}/groups")]
        public async Task<IActionResult> ListGroups(string token, string id)
        {
            var result = await _userService.ListGroups(token, id);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        /// <summary>
        /// List projects for user
        /// </summary>
        [HttpGet("{id}/projects")]
        public async Task<IActionResult> ListProjects(string token, string id)
        {
            var result = await _userService.ListProjects(token, id);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        /// <summary>
        /// Change password for user
        /// </summary>
        [HttpPost("{id}/password")]
        public async Task<IActionResult> ChangePassword(string id, ChangePassword changePassword)
        {
            var result = await _userService.ChangePassword(id, changePassword);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }
    }
}