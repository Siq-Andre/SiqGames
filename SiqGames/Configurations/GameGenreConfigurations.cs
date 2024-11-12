using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiqGames.Entities;

namespace SiqGames.Configurations
{
    public class GameGenreConfigurations: IEntityTypeConfiguration<GameGenre>
    {
        public void Configure (EntityTypeBuilder<GameGenre> builder)
        {
            builder.HasKey(p => new { p.GameId, p.GenreId });

            builder.HasOne(e => e.Game)
                .WithMany(e => e.GameGenres)
                .HasForeignKey(e => e.GameId)
                .IsRequired();

            builder.HasOne(e => e.Genre)
                .WithMany(e => e.GameGenres)
                .HasForeignKey(e => e.GenreId)
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
