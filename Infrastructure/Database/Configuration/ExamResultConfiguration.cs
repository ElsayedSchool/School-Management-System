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
    public class ExamResultConfiguration : IEntityTypeConfiguration<ExamResult>
    {
        public void Configure(EntityTypeBuilder<ExamResult> builder)
        {
            builder.HasKey(p=> new {p.StudentId, p.ExamId});

            builder.Property(p => p.Score).IsRequired();

            builder
                .HasOne(p => p.Exam)
                .WithMany(p => p.Results)
                .HasForeignKey(p => p.ExamId);

            builder
                .HasOne(p => p.Student)
                .WithMany(p => p.Exams)
                .HasForeignKey(p => p.StudentId);
        }
    }
}
