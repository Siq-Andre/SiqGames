using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiqGames.Entities;

namespace SiqGames.Configurations
{
    public class PlayerPlayerConfigurations: IEntityTypeConfiguration<PlayerPlayer>
    {
        public void Configure (EntityTypeBuilder<PlayerPlayer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(e => e.Player1)
                .WithMany(e => e.Player1Friends)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Player2)
                .WithMany(e => e.Player2Friends)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


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
