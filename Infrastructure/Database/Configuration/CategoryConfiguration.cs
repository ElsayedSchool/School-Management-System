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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.CategoryId);

            builder.Property(p => p.CategoryName).HasMaxLength(30).IsRequired();

            builder.Property(p => p.EnglishName).HasMaxLength(30);

            builder
                .HasMany(p => p.SubCategories)
                .WithOne()
                .HasForeignKey(p => p.CategoryParentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(p => p.Groups)
                .WithOne(p => p.Grade)
                .HasForeignKey(p => p.GradeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
