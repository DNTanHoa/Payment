using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.Configuration
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(x => x.bankCode);
            builder.Property(x => x.bankName)
                .HasMaxLength(1000);
            builder.Property(x => x.bankLogo)
                .HasMaxLength(1000);
            builder.Property(x => x.bankShortName)
                .HasMaxLength(250);
            builder.Property(x => x.bankCode)
                .HasMaxLength(250);
            builder.Property(x => x.createdAt)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now);
            builder.Property(x => x.lastUpdatedAt)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now);
        }
    }
}
