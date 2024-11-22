using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiqGames.Entities;
using System.Reflection.Emit;

namespace SiqGames.Configurations
{
    public class PlayerConfigurations: IEntityTypeConfiguration<Player>
    {
        public void Configure (EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(e => e.Id)
                .HasColumnName($"{nameof(Game)}Id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Nickname)
                .HasMaxLength(20)        
                .IsRequired();

            builder.HasIndex(p => p.Nickname)
                .IsUnique();

            builder.Property(p => p.FullName)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasIndex(p => p.Email)
                .IsUnique();

            builder.HasMany(g => g.Games)
                 .WithMany(g => g.Players)
                 .UsingEntity(j => j.ToTable("PlayerGames"));

            builder.HasMany(e => e.Sales)
                .WithOne()
                .IsRequired();

            builder.Property(e => e.BirthDate)
                .IsRequired();

            builder.HasMany(g => g.Studios)
                .WithMany(g => g.Players)
                .UsingEntity(j => j.ToTable("PlayerStudios"));

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
