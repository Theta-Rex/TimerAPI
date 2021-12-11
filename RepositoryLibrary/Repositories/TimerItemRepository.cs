// <copyright file="TimerItemRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace RepositoryLibrary.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using ModelsLibary.Models;

    /// <summary>
    /// TimerItemRepository class.
    /// </summary>
    public class TimerItemRepository : ITimerItemRepository
    {
        private readonly TimerItemContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerItemRepository"/> class.
        /// </summary>
        /// <param name="context">Passes TimerItemContext.</param>
        public TimerItemRepository(TimerItemContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Updates specific item.
        /// </summary>
        /// <param name="timerItem">Object to update.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task<TimerItem> Create(TimerItem timerItem)
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
        public async Task Delete(int timerId)
        {
            var timerToDelete = await this.context.TimerItems.FindAsync(timerId);
            this.context.TimerItems.Remove(timerToDelete);
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<IEnumerable<TimerItem>> Get()
        {
            return await this.context.TimerItems.ToListAsync();
        }

        /// <summary>
        /// Gets specific item.
        /// </summary>
        /// <param name="timerId">Id for specific item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<TimerItem> Get(int timerId)
        {
            return await this.context.TimerItems.FindAsync(timerId);
        }

        /// <summary>
        /// Updates specific item.
        /// </summary>
        /// <param name="timerItem">Object to update.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task Update(TimerItem timerItem)
        {
           this.context.Entry(timerItem).State = EntityState.Modified;
           await this.context.SaveChangesAsync();
        }
    }
}
