// <copyright file="Repository.cs" company="Theta Rex, Inc.">
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
    /// SeverityRepository class.
    /// </summary>
    public class Repository : IRepository
    {
        private readonly TimerItemContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <param name="context">Passes TimerItemContext.</param>
        public Repository(TimerItemContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="severity">Object to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<Severity> CreateSeverity(Severity severity)
        {
            this.context.Severitys.Add(severity);
            await this.context.SaveChangesAsync();

            return severity;
        }

        /// <summary>
        /// Deletes item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task<bool> DeleteSeverity(int id)
        {
            var severityToDelete = await this.context.Severitys.FindAsync(id);
            this.context.Severitys.Remove(severityToDelete);
            await this.context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<IEnumerable<Severity>> GetSeverities()
        {
            return await this.context.Severitys.ToListAsync();
        }

        /// <summary>
        /// Gets specific item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<Severity> GetSeverity(int id)
        {
            return await this.context.Severitys.FindAsync(id);
        }

        /// <summary>
        /// Updates specific item.
        /// </summary>
        /// <param name="severity">Item to update.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task<bool> UpdateSeverity(Severity severity)
        {
            this.context.Entry(severity).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Updates specific item.
        /// </summary>
        /// <param name="timerItem">Object to update.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task<TimerItem> CreateTimerItem(TimerItem timerItem)
        {
            this.context.TimerItems.Add(timerItem);
            await this.context.SaveChangesAsync();

            return timerItem;
        }

        /// <summary>
        /// Deletes item.
        /// </summary>
        /// <param name="timerId">Id for specific item.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task<bool> DeleteTimerItem(int timerId)
        {
            var timerToDelete = await this.context.TimerItems.FindAsync(timerId);
            this.context.TimerItems.Remove(timerToDelete);
            await this.context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<IEnumerable<TimerItem>> GetTimerItems()
        {
            return await this.context.TimerItems.ToListAsync();
        }

        /// <summary>
        /// Gets specific item.
        /// </summary>
        /// <param name="timerId">Id for specific item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<TimerItem> GetTimerItem(int timerId)
        {
            return await this.context.TimerItems.FindAsync(timerId);
        }

        /// <summary>
        /// Updates specific item.
        /// </summary>
        /// <param name="timerItem">Object to update.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task<bool> UpdateTimerItem(TimerItem timerItem)
        {
            this.context.Entry(timerItem).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="user">Object to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<User> CreateUser(User user)
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
        public async Task<bool> DeleteUser(int id)
        {
            var userToDelete = await this.context.Users.FindAsync(id);
            this.context.Users.Remove(userToDelete);
            await this.context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await this.context.Users.ToListAsync();
        }

        /// <summary>
        /// Gets specific item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<User> GetUser(int id)
        {
            return await this.context.Users.FindAsync(id);
        }

        /// <summary>
        /// Updates specific item.
        /// </summary>
        /// <param name="user">Severity object to update.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task<bool> UpdateUser(User user)
        {
            this.context.Entry(user).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
            return true;
        }
    }
}
