using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiqGames.Entities;

namespace SiqGames.Configurations
{
    public class GameConfigurations: IEntityTypeConfiguration<Game>
    {
        public void Configure (EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.GameName)
                .HasMaxLength(60)
                .IsRequired();

            builder.HasOne(e => e.GamePrices)
                .WithOne()
                .HasForeignKey<GamePrice>(e => e.Id)
                .IsRequired();

            builder.HasMany(e => e.GameGenres)
                .WithOne(e => e.Game)
                .HasForeignKey(e => e.GameId)
                .IsRequired(false);

            builder.HasMany(e => e.PlayerGames)
                .WithOne(e => e.Game)
                .HasForeignKey(e => e.GameId)
                .IsRequired(false);

            builder.HasOne(e => e.Studio)
                .WithMany(e => e.Games)
                .HasForeignKey(e => e.Id)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.DateTimeCreated)
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            builder.Property(p => p.UserCreated)
                .HasMaxLength(30)
                .IsRequired()
                .HasDefaultValue("admin");

            builder.Property(p => p.DateTimeModified)
                .IsRequired()
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("getdate()");

            builder.Property(p => p.UserModified)
                .HasMaxLength(30)
                .IsRequired()
                .HasDefaultValue("admin");

            builder.Property(p => p.IsActive)
                .IsRequired()
                .HasDefaultValue(1);
        }
    }
}
