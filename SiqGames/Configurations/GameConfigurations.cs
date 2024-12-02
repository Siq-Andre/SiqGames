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

            builder.Property(e => e.Id)
                .HasColumnName($"{nameof(Game)}Id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Title)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(p => p.Price)
                .HasColumnType("money")
                .IsRequired();

            builder.HasMany(g => g.Genres)
                .WithMany(g => g.Games)
                .UsingEntity(j => j.ToTable("GameGenres"));

            builder.HasMany(e => e.Dlcs)
                .WithOne()
                .IsRequired();

            builder.HasOne(e => e.Studio)
                .WithMany()
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.DateTimeCreated)
                 .IsRequired();

            builder.Property(p => p.UserCreated)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.DateTimeModified)
                .IsRequired();

            builder.Property(p => p.UserModified)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.IsActive)
                .IsRequired();
        }
    }
}
