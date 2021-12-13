// <copyright file="IRepository.cs" company="Theta Rex, Inc.">
//    Copyright © 2021 - Theta Rex, Inc.  All Rights Reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace ModelsLibary.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// IRepository Interface.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Creates a new severity.
        /// </summary>
        /// <param name="severity">Object to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<Severity> CreateSeverity(Severity severity);

        /// <summary>
        /// Creates a new timer item.
        /// </summary>
        /// <param name="timerItem">Object to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<TimerItem> CreateTimerItem(TimerItem timerItem);

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user">Object to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<User> CreateUser(User user);

        /// <summary>
        /// Deletes a severity.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<bool> DeleteSeverity(int id);

        /// <summary>
        /// Deletes a timer item.
        /// </summary>
        /// <param name="timerId">Id for specific item.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<bool> DeleteTimerItem(int timerId);

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<bool> DeleteUser(int id);

        /// <summary>
        /// Gets all severities.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<Severity>> GetSeverities();

        /// <summary>
        /// Gets specific severity.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<Severity> GetSeverity(int id);

        /// <summary>
        /// Gets specific timer item.
        /// </summary>
        /// <param name="timerId">Id for specific item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<TimerItem> GetTimerItem(int timerId);

        /// <summary>
        /// Gets all timer items.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<TimerItem>> GetTimerItems();

        /// <summary>
        /// Gets specific user.
        /// </summary>
        /// <param name="id">Id for specific item.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<User> GetUser(int id);

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<User>> GetUsers();

        /// <summary>
        /// Updates specific severity.
        /// </summary>
        /// <param name="severity">Severity object to update.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<bool> UpdateSeverity(Severity severity);

        /// <summary>
        /// Updates a specific timer item.
        /// </summary>
        /// <param name="timerItem">Object to update.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<bool> UpdateTimerItem(TimerItem timerItem);

        /// <summary>
        /// Updates specific user.
        /// </summary>
        /// <param name="user">Severity object to update.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<bool> UpdateUser(User user);
    }
}
