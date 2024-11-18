using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiqGames.Entities;

namespace SiqGames.Configurations
{
    public class PlayerStudioConfigurations: IEntityTypeConfiguration<PlayerStudio>
    {
        public void Configure (EntityTypeBuilder<PlayerStudio> builder)
        {
            builder.HasKey(p => new { p.PlayerId, p.StudioId });

            builder.HasOne(e => e.Player)
                .WithMany(e => e.PlayerStudios)
                .HasForeignKey(e => e.PlayerId)
                .IsRequired();

            builder.HasOne(e => e.Studio)
                .WithMany(e => e.PlayerStudios)
                .HasForeignKey(e => e.StudioId)
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
