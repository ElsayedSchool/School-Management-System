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
    public class CenterConfiguration : IEntityTypeConfiguration<Center>
    {
        public void Configure(EntityTypeBuilder<Center> builder)
        {
            builder.HasKey(p => p.CenterId);

            builder.Property(p => p.CenterName)
                .IsRequired()
                .HasMaxLength(30)
                .HasDefaultValue("My Center Name");

            builder.Property(p => p.CenterNameInEnglish)
                .IsRequired()
                .HasMaxLength(30)
                .HasDefaultValue("My Center Name");
                    
            builder.Property(p => p.OverView)
                .HasMaxLength(150)
                .HasDefaultValue("All About CenterData Objectiives");


            builder.Property(p => p.IsSchoolInstitue)
                .HasDefaultValue(true);

            builder
                .HasOne(p => p.Setting)
                .WithOne(p => p.Center)
                .HasForeignKey<Setting>(p => p.CenterId);
                

            builder
                .HasMany(p => p.Branches)
                .WithOne()
                .HasForeignKey(p => p.CenterId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(p => p.Branches);
        }
    }
}
