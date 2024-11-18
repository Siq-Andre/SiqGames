using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiqGames.Entities;

namespace SiqGames.Configurations
{
    public class PlayerGameConfigurations: IEntityTypeConfiguration<PlayerGame>
    {
        public void Configure (EntityTypeBuilder<PlayerGame> builder)
        {
            builder.HasKey(p => new { p.PlayerId, p.GameId });

            builder.HasOne(e => e.Player)
                .WithMany(e => e.PlayerGames)
                .HasForeignKey(e => e.PlayerId)
                .IsRequired();

            builder.HasOne(e => e.Game)
                .WithMany(e => e.PlayerGames)
                .HasForeignKey(e => e.GameId)
                .IsRequired();

            builder.Property(e => e.TimePlayed).HasColumnType("time");

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
