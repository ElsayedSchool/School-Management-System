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
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {

        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(p => p.CityId);
            builder.Property(p => p.CityName).IsRequired().HasMaxLength(30);
            builder.Property(p => p.EnglishName).IsRequired().HasMaxLength(30);
            builder.HasIndex(p => new {p.CityName, p.EnglishName});

            builder
                .HasMany(p => p.Regions)
                .WithOne(p => p.City)
                .HasForeignKey(p => p.CityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
