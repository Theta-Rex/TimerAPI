// <copyright file="UsersController.cs" company="Theta Rex, Inc.">
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
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userRepository">Passes userRepository Interface.</param>
        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await this.userRepository.Get();
        }

        /// <summary>
        /// Gets specific item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUsers(int id)
        {
            return await this.userRepository.Get(id);
        }

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="user">Object to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpPost]
        public async Task<ActionResult<User>> PostUsers([FromBody] User user)
        {
            var newUser = await this.userRepository.Create(user);
            return this.StatusCode(201);

            // return this.CreatedAtAction(nameof(GetUsers), new { userId = newUser.Id }, newUser);
        }

        /// <summary>
        /// Updates specific item.
        /// </summary>
        /// <param name="id">Item to update.</param>
        /// <param name="user">Object.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [HttpPut]
        public async Task<ActionResult> PutUsers(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return this.BadRequest();
            }

            await this.userRepository.Update(user);
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
            var userToDelete = await this.userRepository.Get(id);
            if (userToDelete == null)
            {
                return this.NotFound();
            }

            await this.userRepository.Delete(userToDelete.Id);
            return this.NoContent();
        }
    }
}
