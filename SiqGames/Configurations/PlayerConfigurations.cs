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

            builder.Property(p => p.Nickname)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.FullName)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasMany(e => e.PlayerGames)
                .WithOne(e => e.Player)
                .HasForeignKey(e => e.PlayerId)
                .IsRequired(false);

            builder.HasMany(e => e.Sales)
                .WithOne()
                .HasForeignKey(e => e.Id)
                .IsRequired(false);

            builder.Property(e => e.BirthDate)
                .IsRequired();

            builder.HasMany(e => e.Player1Friends)
                .WithOne(e => e.Player1)
                .HasForeignKey(e => e.Player1Id)
                .IsRequired(false);

            builder.HasMany(e => e.Player2Friends)
                .WithOne(e => e.Player2)
                .HasForeignKey(e => e.Player2Id)
                .IsRequired(false);

            builder.HasMany(e => e.PlayerStudios)
                .WithOne(e => e.Player)
                .HasForeignKey(e => e.PlayerId)
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
