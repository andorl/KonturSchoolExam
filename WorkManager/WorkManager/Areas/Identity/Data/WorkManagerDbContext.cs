using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkManager.Areas.Identity.Data;

namespace WorkManager.Models
{
    public sealed class WorkManagerDbContext : IdentityDbContext<AppUser>
    {
        public WorkManagerDbContext(DbContextOptions<WorkManagerDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();

            /*if (Users.Any())
            {
                return;
            }

            Users.AddRange();

            SaveChanges();*/
        }

        public DbSet<Work> Works { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}