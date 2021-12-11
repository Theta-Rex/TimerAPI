// <copyright file="ISeverityRepository.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>

namespace RepositoryLibrary.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ModelsLibary.Models;

    /// <summary>
    /// IServerityRepository Interface.
    /// </summary>
    public interface ISeverityRepository
    {
        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<Severity>> Get();

        /// <summary>
        /// Gets specific item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<Severity> Get(int id);

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="severity">Object to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<Severity> Create(Severity severity);

        /// <summary>
        /// Updates specific item.
        /// </summary>
        /// <param name="severity">Severity object to update.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task Update(Severity severity);

        /// <summary>
        /// Deletes item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task Delete(int id);
    }
}
