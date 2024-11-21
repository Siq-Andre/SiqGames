﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiqGames.Entities;

namespace SiqGames.Configurations
{
    public class DlcConfigurations: IEntityTypeConfiguration<Dlc>
    {
        public void Configure(EntityTypeBuilder<Dlc> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Title)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(p => p.Price)
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