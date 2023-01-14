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
    public class StudentParentConfiguration : IEntityTypeConfiguration<StudentParent>
    {
        public void Configure(EntityTypeBuilder<StudentParent> builder)
        {
            builder.HasKey(p => p.StudentParentId);

            builder
                .HasOne(p=>p.Student)
                .WithMany(p=>p.Parents)
                .HasForeignKey(p=>p.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(p => p.Parent)
                .WithMany(p => p.Childern)
                .HasForeignKey(p => p.ParentId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
