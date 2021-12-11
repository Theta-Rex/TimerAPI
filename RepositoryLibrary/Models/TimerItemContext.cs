using Microsoft.EntityFrameworkCore;
using RepositoryLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryLibrary.Models
{
    public class TimerItemContext : DbContext
    {
        public TimerItemContext(DbContextOptions<TimerItemContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TimerItem> TimerItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Severity> Severitys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimerItem>().ToTable("TimerItems");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Severity>().ToTable("Severitys");
        }

    }
}
