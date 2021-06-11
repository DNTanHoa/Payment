using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.Configuration
{
    public class OrderInforConfiguration : IEntityTypeConfiguration<OrderInfor>
    {
        public void Configure(EntityTypeBuilder<OrderInfor> builder)
        {
            builder.HasKey(x => x.orderId);
            builder.Property(x => x.orderDescription)
                .HasMaxLength(1000);
            builder.Property(x => x.amount)
                .HasColumnType("decimal(19,9)");
            builder.Property(x => x.orderId)
                .HasMaxLength(100);
            builder.Property(x => x.transactionNo)
                .HasMaxLength(100);
            builder.Property(x => x.message)
                .HasMaxLength(100);
            builder.Property(x => x.responseCode)
                .HasMaxLength(100);
            builder.Property(x => x.createdAt)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now);
            builder.Property(x => x.lastUpdatedAt)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now);
        }
    }
}
