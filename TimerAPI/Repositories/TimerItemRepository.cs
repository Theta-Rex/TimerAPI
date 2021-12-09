using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimerAPI.Models;

namespace TimerAPI.Repositories
{
    public class TimerItemRepository : ITimerItemRepository
    {
        private readonly TimerItemContext _context;

        public TimerItemRepository(TimerItemContext context)
        {
            _context = context;
        }

        public async Task<TimerItem> Create(TimerItem timerItem)
        {
            _context.TimerItems.Add(timerItem);
            await _context.SaveChangesAsync();

            return timerItem;
        }

        public async Task Delete(int timerId)
        {
            var timerToDelete = await _context.TimerItems.FindAsync(timerId);
            _context.TimerItems.Remove(timerToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TimerItem>> Get()
        {
            return await _context.TimerItems.ToListAsync();
        }

        public async Task<TimerItem> Get(int timerId)
        {
            return await _context.TimerItems.FindAsync(timerId);
        }

        public async Task Update(TimerItem timerItem)
        {
            _context.Entry(timerItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
