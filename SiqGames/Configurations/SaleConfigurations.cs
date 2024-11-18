using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiqGames.Entities;

namespace SiqGames.Configurations
{
    public class SaleConfigurations: IEntityTypeConfiguration<Sale>
    {
        public void Configure (EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(e => e.GamePrice)
                .WithMany(e => e.Sales)
                .HasForeignKey(e => e.GamePriceId)
                .IsRequired();

            builder.Property(p => p.FinalPrice)
                .HasColumnType("money")
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
