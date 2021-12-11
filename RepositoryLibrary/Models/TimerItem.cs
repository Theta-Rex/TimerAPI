namespace RepositoryLibrary.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class TimerItem
    {
        public int Id { get; set; }
        public int EntryTime { get; set; }
        public int SeverityId { get; set; }
        public int UserId { get; set; }
    }
}
