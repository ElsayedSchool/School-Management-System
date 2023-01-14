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
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(p => p.SessionId);

            builder.Property(p => p.Title).IsRequired().HasDefaultValue("No Title");

            builder.Property(p => p.StartDate).IsRequired();

            builder.Property(p => p.EndDate).IsRequired();

            builder.Property(p => p.ActualStartDate).IsRequired(false);

            builder.Property(p => p.ActualEndDate).IsRequired(false);

            builder.Property(p => p.Status).IsRequired().HasDefaultValue(SessionStatus.none);

            builder
                .HasOne(p=> p.Class)
                .WithMany(p => p.Sessions)
                .HasForeignKey(p => p.ClassId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
