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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(p => p.EmployeeId);
            builder.Property(p => p.Salary).IsRequired();
            
            builder.Property(p => p.AbsenceBalance).IsRequired();
            builder.Property(p => p.WorkStartTime).IsRequired();
            builder.Property(p => p.WorkEndTime).IsRequired();
            builder.Property(p => p.Status).IsRequired().HasDefaultValue(EmployeeStatus.working);
            
            builder
                .HasOne(p=>p.Profile)
                .WithOne(p=>p.Employee)
                .HasForeignKey<Employee>(p=>p.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(p => p.Branch)
                .WithMany(p => p.Employees)
                .HasForeignKey(p => p.BranchId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
