using AutoMapper;
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
    public class ProfileConfiguration:IEntityTypeConfiguration<UserProfile>
    {

        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(p => p.UserProfileId);
            builder.Property(p => p.UserId).IsRequired(false);// to be checked
            builder.Property(p=> p.FirstName).IsRequired().HasMaxLength(20);
            builder.Property(p=> p.LastName).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(13);
            builder.Property(p => p.JobTitle).IsRequired().HasMaxLength(100);
            builder.Property(p => p.HireDate).IsRequired(false).HasDefaultValue(DateTime.Now);
            builder.Property(p => p.ReleaseDate).IsRequired(false);

            builder.Property(p => p.PhotoPath).HasMaxLength(250).IsRequired(false);
            builder.Property(p => p.Photo).IsRequired(false);
            builder.Property(p => p.BirthDate).IsRequired(false);

            builder
                .HasOne(p => p.Manager)
                .WithMany(p => p.DirectReports)
                .HasForeignKey(p => p.ReportsTo)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(p => p.FullName);

        }
    }
}
