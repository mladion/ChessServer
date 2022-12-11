using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public class ChessDbContext : DbContext
    {
        public ChessDbContext(DbContextOptions<ChessDbContext> options) :
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
