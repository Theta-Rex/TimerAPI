// <copyright file="TimerItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Joshua Kraskin</author>
namespace ModelsLibary.Models
{
    public class TimerItem
    {
        public int Id { get; set; }

        public int EntryTime { get; set; }

        public int SeverityId { get; set; }

        public int UserId { get; set; }
    }
}
