using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SpiritIslandLogger.Web.Areas.Identity.Data;

namespace SpiritIslandLogger.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>()
                        .Ignore(i => i.PhoneNumber)
                        .Ignore(i => i.PhoneNumberConfirmed);
            modelBuilder.Entity<MyIdentityUser>()
                        .Ignore(i => i.PhoneNumber)
                        .Ignore(i => i.PhoneNumberConfirmed);
        }
    }
}
