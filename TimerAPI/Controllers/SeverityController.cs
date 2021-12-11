using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using RepositoryLibrary.Models;
using RepositoryLibrary.Repositories;

namespace TimerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeveritysController : ControllerBase
    {
        private readonly ISeverityRepository _severityRepository;

        public SeveritysController(ISeverityRepository severityRepository)
        {
            _severityRepository = severityRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Severity>> GetSeveritys()
        {
            return await _severityRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Severity>> GetSeveritys(int id)
        {
            return await _severityRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Severity>> PostUsers([FromBody] Severity severity)
        {
            var newSeverity = await _severityRepository.Create(severity);
            return CreatedAtAction(nameof(GetSeveritys), new { severityId = newSeverity.Id }, newSeverity);
        }

        [HttpPut]
        public async Task<ActionResult> PutUsers(int id, [FromBody] Severity severity)
        {
            if(id != severity.Id)
            {
                return BadRequest();
            }

            await _severityRepository.Update(severity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var severityToDelete = await _severityRepository.Get(id);
            if(severityToDelete == null)
            {
                return NotFound();
            }

            await _severityRepository.Delete(severityToDelete.Id);
            return NoContent();
        }
    }
}
