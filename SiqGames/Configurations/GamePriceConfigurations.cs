using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiqGames.Entities;

namespace SiqGames.Configurations
{
    public class GamePriceConfigurations: IEntityTypeConfiguration<GamePrice>
    {
        public void Configure (EntityTypeBuilder<GamePrice> builder)
        {
            builder.HasKey(x => x.GamePriceID);

            builder.Property(p => p.Price)
                .HasColumnType("money")
                .IsRequired();

            builder.HasOne(e => e.Game)
                .WithMany(e => e.GamePrices)
                .HasForeignKey(e => e.GameId)
                .IsRequired();

            builder.HasMany(e => e.Sales)
                .WithOne(e => e.GamePrice)
                .HasForeignKey(e => e.GamePriceId)
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
