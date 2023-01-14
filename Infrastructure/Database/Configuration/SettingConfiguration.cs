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
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasKey(p => p.SettingId);

            builder.Property(p => p.StudentAbsenceWarning)
                .HasDefaultValue(4);

            builder.Property(p => p.StudentAbsenceMax)
                .HasDefaultValue(4);

            builder.Property(p => p.TeacherAbsenceWarning)
                .HasDefaultValue(4);

            builder.Property(p => p.TeacherAbsenceMax)
                .HasDefaultValue(4);

            builder.Property(p => p.StudentGradeMin)
                .HasDefaultValue(50);

            builder.Property(p => p.StudentGradeWarning)
                .HasDefaultValue(70);

            builder.Property(p => p.StudentPaymentOverdiewMax)
                .HasDefaultValue(15);

            builder.Property(p => p.StudentPaymentOverdueWarning)
                .HasDefaultValue(5);

            builder.Property(p => p.StaffAbsenceMax)
                .HasDefaultValue(15);

            builder.Property(p => p.StaffAbsenceWarning)
                .HasDefaultValue(10);
        }
    }
}
