// <copyright file="UsersController.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace TimerAPI.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using ModelsLibary.Models;

    /// <summary>
    /// TimerItemsController class.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="repository">Passes userRepository Interface.</param>
        public UsersController(IRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return this.Ok(await this.repository.GetUsers());
        }

        /// <summary>
        /// Gets specific item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers(int id)
        {
            return this.Ok(await this.repository.GetUser(id));
        }

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="user">Object to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<IActionResult> PostUsers([FromBody] User user)
        {
            return this.Ok(await this.repository.CreateUser(user));
        }

        /// <summary>
        /// Updates specific item.
        /// </summary>
        /// <param name="id">Item to update.</param>
        /// <param name="user">Object.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, [FromBody] User user)
        {
            return this.Ok(await this.repository.UpdateUser(user));
        }

        /// <summary>
        /// Deletes item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await this.repository.GetUser(id);
            if (user == null)
            {
                return this.NotFound();
            }

            return this.Ok(await this.repository.DeleteUser(user.Id));
        }
    }
}
