using Microsoft.EntityFrameworkCore;
using SiqGames.Configurations;
using SiqGames.Entities;

namespace SiqGames.Database
{
    public class SiqGamesContext: DbContext
    {
        public SiqGamesContext(DbContextOptions<SiqGamesContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Dlc> Dlcs { get; set; }
        public DbSet<PlayerPlayer> PlayerPlayers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerConfigurations());
            modelBuilder.ApplyConfiguration(new StudioConfigurations());
            modelBuilder.ApplyConfiguration(new GenreConfigurations());
            modelBuilder.ApplyConfiguration(new GameConfigurations());
            modelBuilder.ApplyConfiguration(new SaleConfigurations());
            modelBuilder.ApplyConfiguration(new DlcConfigurations());
            modelBuilder.ApplyConfiguration(new PlayerPlayerConfigurations());
        }
    }
}
