using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Configuration
{
    public class CategoryCourseConfiguration : IEntityTypeConfiguration<CategoryCourse>
    {
        public void Configure(EntityTypeBuilder<CategoryCourse> builder)
        {
            builder.HasKey(p => p.CategoryCourseId);

            builder.Property(p => p.CourseDesc).HasMaxLength(100).HasDefaultValue("").IsRequired();
            builder.Property(p => p.EnglishDesc).HasMaxLength(100).HasDefaultValue("");
            builder.Property(p => p.Semster).HasDefaultValue(SemsterTypes.None);


            builder
                .HasOne(s => s.Course)
                .WithMany(d => d.CategoryCourses)
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(s => s.Category)
                .WithMany(d => d.CategoryCourses)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
