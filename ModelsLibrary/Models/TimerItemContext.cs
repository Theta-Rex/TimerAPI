// <copyright file="TimerItemContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ModelsLibary.Models
{
    using Microsoft.EntityFrameworkCore;

    public class TimerItemContext : DbContext
    {
        public TimerItemContext(DbContextOptions<TimerItemContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
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
