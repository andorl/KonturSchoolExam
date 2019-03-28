using System;
using WorkManager.Areas.Identity.Data;

namespace WorkManager.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }

        public Level? Priority { get; set; }
        public Level? Duration { get; set; }
        public Level? Difficulty { get; set; }

        public Status WorkStatus { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }
    }

    public enum Level
    {
        Low,
        Medium,
        High,
        VeryHigh,
    }

    public enum Status
    {
        Scheduled,
        Completed,
        Cancelled,
        Archived,
        Overdue,
    }
}