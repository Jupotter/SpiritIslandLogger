using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using SpiritIslandLogger.Web.Areas.Identity.Data;
using SpiritIslandLogger.Web.Data;

[assembly: HostingStartup(typeof(SpiritIslandLogger.Web.Areas.Identity.IdentityHostingStartup))]
namespace SpiritIslandLogger.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((_, services) =>
            {
                services.AddDefaultIdentity<MyIdentityUser>(options =>
                         {
                             options.SignIn.RequireConfirmedAccount = false;
                             options.Password.RequireNonAlphanumeric = false;
                             options.Password.RequireDigit = false;
                             options.Password.RequireUppercase = false;
                             options.Password.RequireLowercase = false;
                             options.Password.RequiredLength = 10;
                         })
                        .AddEntityFrameworkStores<ApplicationDbContext>();
            });
        }
    }
}
