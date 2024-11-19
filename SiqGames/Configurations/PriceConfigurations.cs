using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiqGames.Entities;

namespace SiqGames.Configurations
{
    public class PriceConfigurations: IEntityTypeConfiguration<Price>
    {
        public void Configure (EntityTypeBuilder<Price> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Cost)
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
                .ValueGeneratedOnAddOrUpdate()
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
