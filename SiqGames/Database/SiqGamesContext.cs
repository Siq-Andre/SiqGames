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
        public DbSet<PlayerGame> PlayerGames { get; set; }
        public DbSet<PlayerStudio> PlayerStudios { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<PlayerFriend> PlayerFriends { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().Property(p => p.Nickname).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.FullName).HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.Email).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Player>().HasMany(e => e.PlayerGames).WithOne(e => e.Player).HasForeignKey(e => e.PlayerId).IsRequired();
            modelBuilder.Entity<Player>().Property(e => e.BirthDate).IsRequired();
            modelBuilder.Entity<Player>().HasMany(e => e.PlayerFriends).WithOne(e => e.Player1).HasForeignKey(e => e.Player1Id).IsRequired();
            modelBuilder.Entity<Player>().HasMany(e => e.PlayerFriends).WithOne(e => e.Player2).HasForeignKey(e => e.Player2Id).IsRequired();
            modelBuilder.Entity<Player>().HasMany(e => e.PlayerStudios).WithOne(e => e.Player).HasForeignKey(e => e.PlayerId).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.DateTimeCreated).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Player>().Property(p => p.DateTimeModified).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Player>().Property(p => p.UserCreated).HasMaxLength(30).IsRequired().HasDefaultValue("admin");
            modelBuilder.Entity<Player>().Property(p => p.UserModified).HasMaxLength(30).IsRequired().HasDefaultValue("admin");
            modelBuilder.Entity<Player>().Property(p => p.IsActive).IsRequired().HasDefaultValue(1);

            modelBuilder.Entity<Studio>().Property(p => p.StudioName).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Studio>().HasMany(e => e.Games).WithOne(e => e.Studio).HasForeignKey(e => e.StudioId).IsRequired();
            modelBuilder.Entity<Studio>().HasMany(e => e.PlayerStudios).WithOne(e => e.Studio).HasForeignKey(e => e.StudioId).IsRequired();
            modelBuilder.Entity<Studio>().Property(p => p.DateTimeCreated).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Studio>().Property(p => p.DateTimeModified).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Studio>().Property(p => p.UserCreated).IsRequired().HasMaxLength(30).HasDefaultValue("admin");
            modelBuilder.Entity<Studio>().Property(p => p.UserModified).IsRequired().HasMaxLength(30).HasDefaultValue("admin");
            modelBuilder.Entity<Studio>().Property(p => p.IsActive).IsRequired().HasDefaultValue(1);

            modelBuilder.Entity<Genre>().Property(p => p.GenreName).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Genre>().HasMany(e => e.GameGenres).WithOne(e => e.Genre).HasForeignKey(e => e.GenreId).IsRequired();
            modelBuilder.Entity<Genre>().Property(p => p.DateTimeCreated).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Genre>().Property(p => p.DateTimeModified).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Genre>().Property(p => p.UserCreated).HasMaxLength(30).IsRequired().HasDefaultValue("admin");
            modelBuilder.Entity<Genre>().Property(p => p.UserModified).HasMaxLength(30).IsRequired().HasDefaultValue("admin");
            modelBuilder.Entity<Genre>().Property(p => p.IsActive).IsRequired().HasDefaultValue(1);

            modelBuilder.Entity<Game>().Property(p => p.GameName).HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Game>().HasMany(e => e.GamePrices).WithOne(e => e.Game).HasForeignKey(e => e.GameId).IsRequired();
            modelBuilder.Entity<Game>().HasMany(e => e.GameGenres).WithOne(e => e.Game).HasForeignKey(e => e.GameId).IsRequired();
            modelBuilder.Entity<Game>().HasMany(e => e.PlayerGames).WithOne(e => e.Game).HasForeignKey(e => e.GameId).IsRequired(); 
            modelBuilder.Entity<Game>().HasOne(e => e.Studio).WithMany(e => e.Games).HasForeignKey(e => e.StudioId).IsRequired();
            modelBuilder.Entity<Game>().Property(p => p.Description).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Game>().Property(p => p.DateTimeCreated).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Game>().Property(p => p.DateTimeModified).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Game>().Property(p => p.UserCreated).HasMaxLength(30).IsRequired().HasDefaultValue("admin");
            modelBuilder.Entity<Game>().Property(p => p.UserModified).HasMaxLength(30).IsRequired().HasDefaultValue("admin");
            modelBuilder.Entity<Game>().Property(p => p.IsActive).IsRequired().HasDefaultValue(1);

            modelBuilder.Entity<GamePrice>().Property(p => p.Price).HasColumnType("money").IsRequired();
            modelBuilder.Entity<GamePrice>().HasOne(e => e.Game).WithMany(e => GamePrices).HasForeignKey(e => e.GameId).IsRequired();
            modelBuilder.Entity<GamePrice>().HasMany(e => e.Sales).WithOne(e => e.GamePrice).HasForeignKey(e => e.GamePriceId).IsRequired();
            modelBuilder.Entity<GamePrice>().Property(p => p.DateTimeCreated).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<GamePrice>().Property(p => p.DateTimeModified).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<GamePrice>().Property(p => p.UserCreated).HasMaxLength(30).IsRequired().HasDefaultValue("admin");
            modelBuilder.Entity<GamePrice>().Property(p => p.UserModified).HasMaxLength(30).IsRequired().HasDefaultValue("admin");
            modelBuilder.Entity<GamePrice>().Property(p => p.IsActive).IsRequired().HasDefaultValue(1);

            modelBuilder.Entity<Sale>().HasOne(e => e.Player).WithMany(e => Sales).HasForeignKey(e => e.PlayerId).IsRequired();
            modelBuilder.Entity<Sale>().HasOne(e => e.GamePrice).WithMany(e => Sales).HasForeignKey(e => e.GamePriceId).IsRequired();
            modelBuilder.Entity<Sale>().Property(p => p.FinalPrice).HasColumnType("money").IsRequired();
            modelBuilder.Entity<Sale>().Property(p => p.DateTimeCreated).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Sale>().Property(p => p.DateTimeModified).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Sale>().Property(p => p.UserCreated).HasMaxLength(30).IsRequired().HasDefaultValue("admin");
            modelBuilder.Entity<Sale>().Property(p => p.UserModified).HasMaxLength(30).IsRequired().HasDefaultValue("admin");
            modelBuilder.Entity<Sale>().Property(p => p.IsActive).IsRequired().HasDefaultValue(1);

            modelBuilder.Entity<PlayerGame>().HasKey(p => new { p.PlayerId, p.GameId });
            modelBuilder.Entity<PlayerGame>().HasOne(e => e.Player).WithMany(e => PlayerGames).HasForeignKey(e => e.PlayerId).IsRequired();
            modelBuilder.Entity<PlayerGame>().HasOne(e => e.Game).WithMany(e => PlayerGames).HasForeignKey(e => e.GameId).IsRequired();
            modelBuilder.Entity<PlayerGame>().Property(e => e.TimePlayed).HasColumnType("time");
            modelBuilder.Entity<PlayerGame>().Property(p => p.DateTimeCreated).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<PlayerGame>().Property(p => p.DateTimeModified).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<PlayerGame>().Property(p => p.UserCreated).HasMaxLength(30).IsRequired().HasDefaultValue("admin");
            modelBuilder.Entity<PlayerGame>().Property(p => p.UserModified).HasMaxLength(30).IsRequired().HasDefaultValue("admin");
            modelBuilder.Entity<PlayerGame>().Property(p => p.IsActive).IsRequired().HasDefaultValue(1);

            modelBuilder.Entity<PlayerStudio>().HasKey(p => new { p.PlayerId, p.StudioId });
            modelBuilder.Entity<PlayerStudio>().HasOne(e => e.Player).WithMany(e => PlayerStudios).HasForeignKey(e => e.PlayerId).IsRequired();
            modelBuilder.Entity<PlayerStudio>().HasOne(e => e.Studio).WithMany(e => PlayerStudios).HasForeignKey(e => e.StudioId).IsRequired();
            modelBuilder.Entity<PlayerStudio>().Property(p => p.DateTimeCreated).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<PlayerStudio>().Property(p => p.DateTimeModified).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<PlayerStudio>().Property(p => p.UserCreated).HasMaxLength(30).IsRequired().HasDefaultValue("admin");
            modelBuilder.Entity<PlayerStudio>().Property(p => p.UserModified).HasMaxLength(30).IsRequired().HasDefaultValue("admin");
            modelBuilder.Entity<PlayerStudio>().Property(p => p.IsActive).IsRequired().HasDefaultValue(1);

            modelBuilder.Entity<GameGenre>().HasKey(p => new { p.GameId, p.GenreId });
            modelBuilder.Entity<GameGenre>().HasOne(e => e.Game).WithMany(e => GameGenres).HasForeignKey(e => e.GameId).IsRequired();
            modelBuilder.Entity<GameGenre>().HasOne(e => e.Genre).WithMany(e => GameGenres).HasForeignKey(e => e.GenreId).IsRequired();
            modelBuilder.Entity<GameGenre>().Property(p => p.DateTimeCreated).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<GameGenre>().Property(p => p.DateTimeModified).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<GameGenre>().Property(p => p.UserCreated).HasMaxLength(30).IsRequired().HasDefaultValue("admin");
            modelBuilder.Entity<GameGenre>().Property(p => p.UserModified).HasMaxLength(30).IsRequired().HasDefaultValue("admin");
            modelBuilder.Entity<GameGenre>().Property(p => p.IsActive).IsRequired().HasDefaultValue(1);

            modelBuilder.Entity<PlayerFriend>().HasKey(p => new {p.Player1Id, p.Player2Id});
            modelBuilder.Entity<PlayerFriend>().HasOne(e => e.Player1).WithMany(e => PlayerFriends).HasForeignKey(p => p.Player1Id).IsRequired();
            modelBuilder.Entity<PlayerFriend>().HasOne(e => e.Player2).WithMany(e => PlayerFriends).HasForeignKey(p => p.Player2Id).IsRequired();
            modelBuilder.Entity<PlayerFriend>().Property(p => p.DateTimeCreated).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<PlayerFriend>().Property(p => p.DateTimeModified).IsRequired().HasDefaultValueSql("getdate()");
            modelBuilder.Entity<PlayerFriend>().Property(p => p.UserCreated).HasMaxLength(30).IsRequired().HasDefaultValue("admin");
            modelBuilder.Entity<PlayerFriend>().Property(p => p.UserModified).HasMaxLength(30).IsRequired().HasDefaultValue("admin");
            modelBuilder.Entity<PlayerFriend>().Property(p => p.IsActive).IsRequired().HasDefaultValue(1);
        }
    }
}
