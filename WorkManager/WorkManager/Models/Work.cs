using WorkManager.Areas.Identity.Data;

namespace WorkManager.Models
{
    public class Work
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Payment { get; set; }

        public int UserId { get; set; }
        public AppUser User { get; set; }
    }
}