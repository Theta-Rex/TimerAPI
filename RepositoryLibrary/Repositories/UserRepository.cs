// <copyright file="UserRepository.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace RepositoryLibrary.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using ModelsLibary.Models;

    /// <summary>
    /// UserRepository class.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly TimerItemContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">Passes TimerItemContext.</param>
        public UserRepository(TimerItemContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="user">Object to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<User> Create(User user)
        {
            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();

            return user;
        }

        /// <summary>
        /// Deletes item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task Delete(int id)
        {
            var userToDelete = await this.context.Users.FindAsync(id);
            this.context.Users.Remove(userToDelete);
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<IEnumerable<User>> Get()
        {
            return await this.context.Users.ToListAsync();
        }

        /// <summary>
        /// Gets specific item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<User> Get(int id)
        {
            return await this.context.Users.FindAsync(id);
        }

        /// <summary>
        /// Updates specific item.
        /// </summary>
        /// <param name="user">Severity object to update.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task Update(User user)
        {
            this.context.Entry(user).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }
    }
}
