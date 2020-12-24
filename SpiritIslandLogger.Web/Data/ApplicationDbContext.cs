using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SpiritIslandLogger.Web.Areas.Identity.Data;

namespace SpiritIslandLogger.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Adversary>      Adversaries     { get; set; } = null!;
        public DbSet<AdversaryLevel> AdversaryLevels { get; set; } = null!;
        public DbSet<Spirit>         Spirits         { get; set; } = null!;
        public DbSet<Game>           Games           { get; set; } = null!;
        public DbSet<Player>         Players         { get; set; } = null!;
        public DbSet<GamePlayer>     GamePlayers     { get; set; } = null!;

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
