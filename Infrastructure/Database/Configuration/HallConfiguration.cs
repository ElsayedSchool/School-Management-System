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
    public class HallConfiguration: IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            builder.HasKey(p => p.HallId);
            builder.Property(p => p.HallName).HasMaxLength(30).IsRequired();
            builder.Property(p => p.IsConditioned).IsRequired();
            builder.Property(p => p.MaxStudents).IsRequired().HasDefaultValue(5);
            builder.Property(p => p.PricePerHour).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.PricePerStudent).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.MinReservationTime).IsRequired().HasDefaultValue(1);
            builder.Property(p => p.HourEquivalentTime).IsRequired().HasDefaultValue(30);


            builder
                .HasOne(p => p.Branch)
                .WithMany(p => p.Halls)
                .HasForeignKey(p => p.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
