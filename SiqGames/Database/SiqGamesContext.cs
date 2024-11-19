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
        public DbSet<GamePrice> GamePrices { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<PlayerGame> PlayerGames { get; set; }
        public DbSet<PlayerStudio> PlayerStudios { get; set; }
        public DbSet<PlayerFriend> PlayerFriends { get; set; }      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerConfigurations());
            modelBuilder.ApplyConfiguration(new StudioConfigurations());
            modelBuilder.ApplyConfiguration(new GenreConfigurations());
            modelBuilder.ApplyConfiguration(new GameConfigurations());
            modelBuilder.ApplyConfiguration(new GamePriceConfigurations());
            modelBuilder.ApplyConfiguration(new  SaleConfigurations());
            modelBuilder.ApplyConfiguration(new PlayerGameConfigurations());
            modelBuilder.ApplyConfiguration(new PlayerStudioConfigurations());
            modelBuilder.ApplyConfiguration(new PlayerFriendConfigurations());
        }
    }
}
