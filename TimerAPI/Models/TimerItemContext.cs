using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimerAPI.Models
{
    public class TimerItemContext : DbContext
    {
        public TimerItemContext(DbContextOptions<TimerItemContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TimerItem> TimerItems { get; set; }
    }
}
