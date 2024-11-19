using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiqGames.Entities;

namespace SiqGames.Configurations
{
    public class StudioConfigurations: IEntityTypeConfiguration<Studio>
    {
        public void Configure (EntityTypeBuilder<Studio> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.StudioName)
                .HasMaxLength(30)
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
