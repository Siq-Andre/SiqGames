using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiqGames.Entities;

namespace SiqGames.Configurations
{
    public class GenreConfigurations : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                .HasColumnName($"{nameof(Genre)}Id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.GenreName)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(p => p.GenreName)
                .IsUnique();

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
