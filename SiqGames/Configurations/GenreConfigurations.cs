using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiqGames.Entities;

namespace SiqGames.Configurations
{
    public class GenreConfigurations: IEntityTypeConfiguration<Genre>
    {
        public void Configure (EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x => x.GenreId);

            builder.Property(p => p.GenreName)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasMany(e => e.GameGenres)
                .WithOne(e => e.Genre)
                .HasForeignKey(e => e.GenreId)
                .IsRequired(false);

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
