// <copyright file="SeverityController.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerAPI.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using ModelsLibary.Models;
    using RepositoryLibrary.Repositories;

    /// <summary>
    /// SeverityController class.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SeverityController : ControllerBase
    {
        private readonly ISeverityRepository severityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeverityController"/> class.
        /// </summary>
        /// <param name="severityRepository">Passes severityrepository interface.</param>
        public SeverityController(ISeverityRepository severityRepository)
        {
            this.severityRepository = severityRepository;
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IEnumerable<Severity>> GetSeveritys()
        {
            return await this.severityRepository.Get();
        }

        /// <summary>
        /// Gets specific item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("{id}")]

        public async Task<ActionResult<Severity>> GetSeveritys(int id)
        {
            return await this.severityRepository.Get(id);
        }

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="severity">Object to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<ActionResult<Severity>> PostUsers([FromBody] Severity severity)
        {
            var newSeverity = await this.severityRepository.Create(severity);
            return this.StatusCode(201);

            // return CreatedAtAction(nameof(GetSeveritys), new { severityId = newSeverity.Id }, newSeverity);
        }

        /// <summary>
        /// Updates specific item.
        /// </summary>
        /// <param name="id">Item to update.</param>
        /// <param name="severity">Object.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpPut]
        public async Task<ActionResult> PutUsers(int id, [FromBody] Severity severity)
        {
            if (id != severity.Id)
            {
                return this.BadRequest();
            }

            await this.severityRepository.Update(severity);
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
            var severityToDelete = await this.severityRepository.Get(id);
            if (severityToDelete == null)
            {
                return this.NotFound();
            }

            await this.severityRepository.Delete(severityToDelete.Id);
            return this.NoContent();
        }
    }
}
