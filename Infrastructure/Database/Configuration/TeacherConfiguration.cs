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
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(p => p.TeacherId);

            builder.Property(p => p.YearsOfExperience).IsRequired();

            builder
                .HasOne(p=>p.Profile)
                .WithOne(p=>p.Teacher)
                .HasForeignKey<Teacher>(p=>p.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Course)
                .WithMany(p => p.Teachers)
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
