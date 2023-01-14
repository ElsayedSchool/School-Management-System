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
    public class ClassConfiguration: IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(p => p.ClassId);
            builder.Property(p => p.ClassPrice).IsRequired();

            builder
                .HasOne(p => p.Course)
                .WithMany(p => p.Classes)
                .HasForeignKey(p => p.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Group)
                .WithMany(p => p.Classes)
                .HasForeignKey(p => p.GroupId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Hall)
                .WithMany(p => p.Classes)
                .HasForeignKey(p => p.HallId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Teacher)
                .WithMany(p => p.Classes)
                .HasForeignKey(p => p.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
