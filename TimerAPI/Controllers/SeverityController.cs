// <copyright file="SeverityController.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerAPI.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using ModelsLibary.Models;

    /// <summary>
    /// SeverityController class.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SeverityController : ControllerBase
    {
        /// <summary>
        /// The repository for persistent data.
        /// </summary>
        private readonly IRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeverityController"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public SeverityController(IRepository repository)
        {
            // Initialize the object.
            this.repository = repository;
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> GetSeverities()
        {
            return this.Ok(await this.repository.GetSeverities());
        }

        /// <summary>
        /// Gets specific item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("{id}")]

        public async Task<IActionResult> GetSeveritys(int id)
        {
            return this.Ok(await this.repository.GetSeverity(id));
        }

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="severity">Object to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> PostSeverity([FromBody] Severity severity)
        {
            return this.Ok(await this.repository.CreateSeverity(severity));
        }

        /// <summary>
        /// Updates specific item.
        /// </summary>
        /// <param name="id">Item to update.</param>
        /// <param name="severity">Object.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeverity(int id, [FromBody] Severity severity)
        {
            return this.Ok(await this.repository.UpdateSeverity(severity));
        }

        /// <summary>
        /// Deletes item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeverity(int id)
        {
            var severity = await this.repository.GetSeverity(id);
            if (severity == null)
            {
                return this.NotFound();
            }

            return this.Ok(await this.repository.DeleteSeverity(severity.Id));
        }
    }
}