using System.Threading.Tasks;
using Keystone.Net.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keystone.Net.Test.Controllers
{
    [Route("api/domains")]
    [ApiController]
    public class DomainsController : ControllerBase
    {
        private readonly DomainService _domainService;

        public DomainsController(DomainService domainService)
        {
            _domainService = domainService;
        }

        /// <summary>
        /// List domains
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> List(string token)
        {
            var result = await _domainService.List(token);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body);
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        /// <summary>
        /// Create domain
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(string token, Domain domain)
        {
            var result = await _domainService.Create(token, domain);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        /// <summary>
        /// Show domain details
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(string token, string id)
        {
            var result = await _domainService.Details(token, id);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        /// <summary>
        /// Update domain
        /// </summary>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(string token, string id, Domain domain)
        {
            var result = await _domainService.Update(token, id, domain);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }

        /// <summary>
        /// Delete domain
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string token, string id)
        {
            var result = await _domainService.Delete(token, id);

            if (result.IsSuccessStatusCode)
            {
                return Ok(result.Body.ToString());
            }

            return StatusCode((int)result.StatusCode, result.Message);
        }
    }
}