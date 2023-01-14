using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Configuration
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(p => p.CountryId);
            builder.Property(p => p.CountryName).IsRequired().HasMaxLength(30);
            builder.Property(p => p.EnglishName).HasMaxLength(30);
            builder.HasIndex(p => new { p.CountryName, p.EnglishName });

            builder
                .HasMany(p => p.Cities)
                .WithOne()
                .HasForeignKey(p => p.CountryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
