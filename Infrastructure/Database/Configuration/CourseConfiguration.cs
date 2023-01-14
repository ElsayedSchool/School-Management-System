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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {

        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(p => p.CourseId);
            
            builder.Property(p => p.CourseName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.EnglishName)
                .HasMaxLength(30);

            
        }
    }
}
