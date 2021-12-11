// <copyright file="SeverityRepository.cs" company="Theta Rex, Inc.">
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
    public class SeverityRepository : ISeverityRepository
    {
        private readonly TimerItemContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeverityRepository"/> class.
        /// </summary>
        /// <param name="context">Passes TimerItemContext.</param>
        public SeverityRepository(TimerItemContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="severity">Object to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<Severity> Create(Severity severity)
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
        public async Task Delete(int id)
        {
            var severityToDelete = await this.context.Severitys.FindAsync(id);
            this.context.Severitys.Remove(severityToDelete);
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<IEnumerable<Severity>> Get()
        {
            return await this.context.Severitys.ToListAsync();
        }

        /// <summary>
        /// Gets specific item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public async Task<Severity> Get(int id)
        {
            return await this.context.Severitys.FindAsync(id);
        }

        /// <summary>
        /// Updates specific item.
        /// </summary>
        /// <param name="severity">Item to update.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task Update(Severity severity)
        {
            this.context.Entry(severity).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }
    }
}
