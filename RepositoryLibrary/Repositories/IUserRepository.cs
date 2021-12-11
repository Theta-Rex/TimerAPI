// <copyright file="IUserRepository.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>

namespace RepositoryLibrary.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ModelsLibary.Models;

    /// <summary>
    /// IUserRepository Interface.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<User>> Get();

        /// <summary>
        /// Gets specific item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<User> Get(int id);

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="user">Object to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<User> Create(User user);

        /// <summary>
        /// Updates specific item.
        /// </summary>
        /// <param name="user">Severity object to update.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task Update(User user);

        /// <summary>
        /// Deletes item.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task Delete(int id);
    }
}
