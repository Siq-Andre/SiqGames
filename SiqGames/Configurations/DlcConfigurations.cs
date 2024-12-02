using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiqGames.Entities;

namespace SiqGames.Configurations
{
    public class DlcConfigurations: IEntityTypeConfiguration<Dlc>
    {
        public void Configure(EntityTypeBuilder<Dlc> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                .HasColumnName($"{nameof(Dlc)}Id")
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.Title)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(p => p.Price)
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
