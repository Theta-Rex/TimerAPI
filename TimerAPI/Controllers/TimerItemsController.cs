// <copyright file="TimerItemsController.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerAPI.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using ModelsLibary.Models;
    using RepositoryLibrary.Repositories;

    /// <summary>
    /// TimerItemsController class.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TimerItemsController : ControllerBase
    {
        private readonly ITimerItemRepository timerItemRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerItemsController"/> class.
        /// </summary>
        /// <param name="timerItemRepository">Passes timerItemRepository Inteface.</param>
        public TimerItemsController(ITimerItemRepository timerItemRepository)
        {
            this.timerItemRepository = timerItemRepository;
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IEnumerable<TimerItem>> GetTimerItems()
        {
            return await this.timerItemRepository.Get();
        }

        /// <summary>
        /// Gets specific item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TimerItem>> GetTimerItems(int id)
        {
            return await this.timerItemRepository.Get(id);
        }

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="timerItem">Object to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<ActionResult<TimerItem>> PostTimerItems([FromBody] TimerItem timerItem)
        {
            var newTimerItem = await this.timerItemRepository.Create(timerItem);
            return this.StatusCode(201);

            // return CreatedAtAction(nameof(GetTimerItems), new { timerId = newTimerItem.Id }, newTimerItem);
        }

        /// <summary>
        /// Updates specific item.
        /// </summary>
        /// <param name="id">Item to update.</param>
        /// <param name="timerItem">Object.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpPut]
        public async Task<ActionResult> PutTimerItems(int id, [FromBody] TimerItem timerItem)
        {
            if (id != timerItem.Id)
            {
                return this.BadRequest();
            }

            await this.timerItemRepository.Update(timerItem);
            return this.NoContent();
        }

        /// <summary>
        /// Deletes item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var timerItemToDelete = await this.timerItemRepository.Get(id);
            if (timerItemToDelete == null)
            {
                return this.NotFound();
            }

            await this.timerItemRepository.Delete(timerItemToDelete.Id);
            return this.NoContent();
        }
    }
}
