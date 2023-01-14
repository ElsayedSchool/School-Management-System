using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.CustomValidators;

namespace Infrastructure.Database.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(p => p.StudentId);

            builder.Property(p => p.UserId).IsRequired(false);

            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(20);

            builder.Property(p => p.LastName).IsRequired().HasMaxLength(20);

            builder.Property(p => p.Phone).IsRequired().HasMaxLength(13);

            builder.Property(p => p.Email).HasMaxLength(50).IsRequired(false);

            builder.Ignore(p => p.FullName);

        }
    }
}
