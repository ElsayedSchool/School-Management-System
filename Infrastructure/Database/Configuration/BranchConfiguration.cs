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
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasKey(p => p.BranchId);
            
            builder.Property(p => p.BranchName).HasMaxLength(30).IsRequired();
            builder.HasIndex(p => new { p.BranchId, p.BranchName }).IsUnique();

            builder.Property(p => p.BranchDesc).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(50);
            builder.Property(p => p.Phone1).HasMaxLength(15).IsRequired();
            builder.Property(p => p.Phone2).HasMaxLength(15);
            builder.Ignore(p => p.AddressDesc);
            builder.Ignore(p => p.EnglishDesc);

            builder.Property(p=>p.Street).HasMaxLength(80).IsRequired();
            
            builder
                .HasOne(p=>p.Country)
                .WithOne()
                .HasForeignKey<Branch>(p=>p.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.City)
                .WithOne()
                .HasForeignKey<Branch>(p => p.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Region)
                .WithOne()
                .HasForeignKey<Branch>(p => p.RegionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
