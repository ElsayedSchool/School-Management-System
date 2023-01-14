using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(p => p.AddressId);
            builder.Property(p => p.PostalCode).HasDefaultValue(21111).IsRequired(false);
            builder.Property(p => p.AddressDetails).HasMaxLength(100).IsRequired(false);
            builder.Property(p => p.RegionId).IsRequired(false);   

            builder
                .HasOne(p=>p.User)
                .WithOne(p => p.Address)
                .HasForeignKey<Address>(p=>p.AddressId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
