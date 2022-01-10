// <copyright file="TimerItemsController.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerAPI.Controllers
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using ModelsLibary.Models;

    /// <summary>
    /// TimerItemsController class.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TimerItemsController : ControllerBase
    {
        /// <summary>
        /// The repository for persistent data.
        /// </summary>
        private readonly IRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerItemsController"/> class.
        /// </summary>
        /// <param name="repository">Passes timerItemRepository Inteface.</param>
        public TimerItemsController(IRepository repository)
        {
            // Initialize the object.
            this.repository = repository;
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> GetTimerItems()
        {
            try
            {
                return this.Ok(await this.repository.GetTimerItems());
            }
            catch (HttpRequestException)
            {
                return this.BadRequest();
            }
        }

        /// <summary>
        /// Gets specific item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTimerItems(int id)
        {
            try
            {
                return this.Ok(await this.repository.GetTimerItem(id));
            }
            catch
            {
                return this.NotFound();
            }
        }

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="timerItem">Object to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> PostTimerItems([FromBody] TimerItem timerItem)
        {
            return this.Ok(await this.repository.CreateTimerItem(timerItem));
        }

        /// <summary>
        /// Updates specific item.
        /// </summary>
        /// <param name="id">Item to update.</param>
        /// <param name="timerItem">Object.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimerItems(int id, [FromBody] TimerItem timerItem)
        {
            if (id != timerItem.Id)
            {
                return this.BadRequest();
            }

            return this.Ok(await this.repository.UpdateTimerItem(timerItem));
        }

        /// <summary>
        /// Deletes item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var timerItem = await this.repository.GetTimerItem(id);
            if (timerItem == null)
            {
                return this.NotFound();
            }

            return this.Ok(await this.repository.DeleteTimerItem(timerItem.Id));
        }
    }
}
