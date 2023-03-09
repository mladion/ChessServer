using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class ChessDbContext : IdentityDbContext
    {
        public ChessDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>()
                .HasOne(x => x.WhiteUser)
                .WithMany(x => x.WhiteGames)
                .HasForeignKey(x => x.WhiteUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Game>()
                .HasOne(x => x.BlackUser)
                .WithMany(x => x.BlackGames)
                .HasForeignKey(x => x.BlackUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
