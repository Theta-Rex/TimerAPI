// <copyright file="TimerItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace ModelsLibary.Models
{
    /// <summary>
    /// Model for TimerItem.
    /// </summary>
    public class TimerItem
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets EntryTime.
        /// </summary>
        public int EntryTime { get; set; }

        /// <summary>
        /// Gets or sets SeverityId.
        /// </summary>
        public int SeverityId { get; set; }

        /// <summary>
        /// Gets or sets UserId.
        /// </summary>
        public int UserId { get; set; }
    }
}
