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

            builder.Property(e => e.Id)
                .HasColumnName($"{nameof(Sale)}Id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasOne(e => e.Game)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.HasOne(e => e.Dlc)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.Property(p => p.FinalPrice)
                .HasColumnType("money")
                .IsRequired();

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
