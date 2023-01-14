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
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.HasKey(p => p.ExamId);

            builder.Property(p => p.Date).IsRequired(false);

            builder.Property(p=>p.OverView).IsRequired(false).HasMaxLength(150);

            builder.Property(p => p.TotalDegree).IsRequired();

            builder
                .HasOne(p => p.Class)
                .WithMany(p => p.Exams)
                .HasForeignKey(p => p.ClassId);
            
            builder
                .HasOne(p => p.Session)
                .WithOne(p => p.Exam)
                .HasForeignKey<Exam>(p => p.SessionId)
                .IsRequired(false);

        }
    }
}
