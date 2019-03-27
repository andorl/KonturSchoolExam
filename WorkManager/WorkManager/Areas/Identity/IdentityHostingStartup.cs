using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkManager.Areas.Identity.Data;
using WorkManager.Models;

[assembly: HostingStartup(typeof(WorkManager.Areas.Identity.IdentityHostingStartup))]
namespace WorkManager.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WorkManagerDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WorkManagerDbContextConnection")));

                services.AddDefaultIdentity<WorkManagerUser>()
                    .AddEntityFrameworkStores<WorkManagerDbContext>();
            });
        }
    }
}