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
    public class GroupConfiguration: IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(p => p.GroupId);
            builder.Property(p => p.GroupName).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Studentpayment).IsRequired();


            builder
                .HasOne(p => p.Branch)
                .WithMany(p => p.Groups)
                .HasForeignKey(p => p.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
