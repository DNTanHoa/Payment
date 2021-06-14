using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.code);

            builder.Property(x => x.name)
                .HasMaxLength(1000);
            builder.Property(x => x.address)
                .HasMaxLength(1000);
            builder.Property(x => x.fullAddress)
                .HasMaxLength(1000);

            builder.Property(x => x.phone)
                .HasMaxLength(100);
            builder.Property(x => x.email)
                .HasMaxLength(100);
            builder.Property(x => x.fax)
                .HasMaxLength(100);
            builder.Property(x => x.identityNumber)
                .HasMaxLength(100);
            builder.Property(x => x.taxCode)
                .HasMaxLength(100);
        }
    }
}
