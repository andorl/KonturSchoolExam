using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WorkManager.Models
{
    // Add profile data for application users by adding properties to the AppUser class
    public class AppUser : IdentityUser
    {
        public ICollection<Work> Works { get; set; }
    }
}