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
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {


        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(p => p.RegionId);
            builder.Property(p => p.RegionName).IsRequired().HasMaxLength(30);
            builder.Property(p => p.EnglishName).IsRequired().HasMaxLength(30);
            builder.HasIndex(p => new { p.RegionName, p.EnglishName });

            builder
                .HasMany(p => p.Addresses)
                .WithOne(p => p.Region)
                .HasForeignKey(p => p.RegionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
