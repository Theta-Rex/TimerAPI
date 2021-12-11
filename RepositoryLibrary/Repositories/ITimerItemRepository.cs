// <copyright file="ITimerItemRepository.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>

namespace RepositoryLibrary.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ModelsLibary.Models;

    /// <summary>
    /// ITimerRepository Interface.
    /// </summary>
    public interface ITimerItemRepository
    {
        /// <summary>
        /// Gets all items.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<TimerItem>> Get();

        /// <summary>
        /// Gets specific item.
        /// </summary>
        /// <param name="timerId">Id for specific item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<TimerItem> Get(int timerId);

        /// <summary>
        /// Creates a new item.
        /// </summary>
        /// <param name="timerItem">Object to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<TimerItem> Create(TimerItem timerItem);

        /// <summary>
        /// Updates specific item.
        /// </summary>
        /// <param name="timerItem">Object to update.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task Update(TimerItem timerItem);

        /// <summary>
        /// Deletes item.
        /// </summary>
        /// <param name="timerId">Id for specific item.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task Delete(int timerId);
    }
}
