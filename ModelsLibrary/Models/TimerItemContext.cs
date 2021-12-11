// <copyright file="TimerItemContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace ModelsLibary.Models
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// TimerItem Context.
    /// </summary>
    public class TimerItemContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimerItemContext"/> class.
        /// </summary>
        /// <param name="options">Configures options.</param>
        public TimerItemContext(DbContextOptions<TimerItemContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or sets TimerItems.
        /// </summary>
        public DbSet<TimerItem> TimerItems { get; set; }

        /// <summary>
        /// Gets or sets Users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets Severitys.
        /// </summary>
        public DbSet<Severity> Severitys { get; set; }

        /// <summary>
        /// Creates Tables.
        /// </summary>
        /// <param name="modelBuilder">Passes modelBuilder parameter.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimerItem>().ToTable("TimerItems");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Severity>().ToTable("Severitys");
        }
    }
}
