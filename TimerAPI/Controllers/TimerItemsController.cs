using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepositoryLibrary.Repositories;
using ModelsLibary.Models;

namespace TimerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimerItemsController : ControllerBase
    {
        private readonly ITimerItemRepository _timerItemRepository;

        public TimerItemsController(ITimerItemRepository timerItemRepository)
        {
            _timerItemRepository = timerItemRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TimerItem>> GetTimerItems()
        {
            return await _timerItemRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimerItem>> GetTimerItems(int id)
        {
            return await _timerItemRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<TimerItem>> PostTimerItems([FromBody] TimerItem timerItem)
        {
            var newTimerItem = await _timerItemRepository.Create(timerItem);
            return CreatedAtAction(nameof(GetTimerItems), new { timerId = newTimerItem.Id }, newTimerItem);
        }

        [HttpPut]
        public async Task<ActionResult> PutTimerItems(int id, [FromBody] TimerItem timerItem)
        {
            if(id != timerItem.Id)
            {
                return BadRequest();
            }

            await _timerItemRepository.Update(timerItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var timerItemToDelete = await _timerItemRepository.Get(id);
            if(timerItemToDelete == null)
            {
                return NotFound();
            }

            await _timerItemRepository.Delete(timerItemToDelete.Id);
            return NoContent();
        }
    }
}
