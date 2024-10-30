using Microsoft.EntityFrameworkCore;
using SiqGames.Model;

namespace SiqGames.Database
{
    public class SiqGamesContext: DbContext
    {
        public SiqGamesContext(): base() { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GamePrice> GamePrices { get; set; }
        public DbSet<Sale> Sales { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().Property(p => p.Nickname).HasMaxLength(20);
            modelBuilder.Entity<Player>().Property(p => p.FullName).HasMaxLength(60);
            modelBuilder.Entity<Player>().Property(p => p.Email).HasMaxLength(30);
            modelBuilder.Entity<Player>().Property(p => p.DateTimeCreated).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Player>().Property(p => p.DateTimeModified).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Player>().Property(p => p.UserCreated).HasMaxLength(30).HasDefaultValue("admin");
            modelBuilder.Entity<Player>().Property(p => p.UserModified).HasMaxLength(30).HasDefaultValue("admin");
            modelBuilder.Entity<Player>().Property(p => p.IsActive).HasDefaultValue(1);
        }
    }
}
