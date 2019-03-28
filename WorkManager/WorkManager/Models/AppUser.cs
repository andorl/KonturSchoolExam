using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WorkManager.Models;

namespace WorkManager.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AppUser class
    public class AppUser : IdentityUser
    {
        public AppUser(string userName) : base(userName)
        {
        }

        public ICollection<Work> Works { get; set; }
    }
}