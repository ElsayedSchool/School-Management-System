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
    public class AbsenceConfiguration : IEntityTypeConfiguration<StudentAbsence>
    {
        public void Configure(EntityTypeBuilder<StudentAbsence> builder)
        {
            builder.HasKey(p => new { p.StudentId, p.SessionId });

            builder.HasIndex(p => new { p.StudentId, p.SessionId }).IsUnique();

            builder.Property(p => p.IsSick);

            builder
                .HasOne(p => p.Student)
                .WithMany(p => p.AbsenceList)
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Session)
                .WithMany(p => p.AbsenceStudents)
                .HasForeignKey(p => p.SessionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
