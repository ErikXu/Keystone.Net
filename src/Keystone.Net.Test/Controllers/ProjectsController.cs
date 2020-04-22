using System.Threading.Tasks;
using Keystone.Net.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keystone.Net.Test.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectService _projectService;

        public ProjectsController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        /// <summary>
        /// List projects
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> List(string token)
        {
            var result = await _projectService.List(token);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        /// <summary>
        /// Create project
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(string token, Project project)
        {
            var result = await _projectService.Create(token, project);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        /// <summary>
        /// Show project details
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(string token, string id)
        {
            var result = await _projectService.Details(token, id);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        /// <summary>
        /// Update project
        /// </summary>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(string token, string id, Project project)
        {
            var result = await _projectService.Update(token, id, project);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        /// <summary>
        /// Delete project
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string token, string id)
        {
            var result = await _projectService.Delete(token, id);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }
    }
}