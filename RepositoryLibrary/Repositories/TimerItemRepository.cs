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

    public class TimerItemRepository : ITimerItemRepository
    {
        private readonly TimerItemContext context;

        public TimerItemRepository(TimerItemContext context)
        {
            this.context = context;
        }

        public async Task<TimerItem> Create(TimerItem timerItem)
        {
            this.context.TimerItems.Add(timerItem);
            await this.context.SaveChangesAsync();

            return timerItem;
        }

        public async Task Delete(int timerId)
        {
            var timerToDelete = await this.context.TimerItems.FindAsync(timerId);
            this.context.TimerItems.Remove(timerToDelete);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TimerItem>> Get()
        {
            return await this.context.TimerItems.ToListAsync();
        }

        public async Task<TimerItem> Get(int timerId)
        {
            return await this.context.TimerItems.FindAsync(timerId);
        }

        public async Task Update(TimerItem timerItem)
        {
           this.context.Entry(timerItem).State = EntityState.Modified;
           await this.context.SaveChangesAsync();
        }
    }
}
