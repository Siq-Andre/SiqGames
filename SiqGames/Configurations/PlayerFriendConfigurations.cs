using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiqGames.Entities;

namespace SiqGames.Configurations
{
    public class PlayerFriendConfigurations: IEntityTypeConfiguration<PlayerFriend>
    {
        public void Configure (EntityTypeBuilder<PlayerFriend> builder)
        {
            builder.HasKey(p => new { p.Player1Id, p.Player2Id });

            builder.HasOne(e => e.Player1)
                .WithMany(e => e.Player1Friends)
                .HasForeignKey(p => p.Player1Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Player2)
                .WithMany(e => e.Player2Friends)
                .HasForeignKey(p => p.Player2Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(b => b.HasCheckConstraint("CK_Player1Id_LessThan_Player2Id", "[Player1Id] < [Player2Id]"));


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
