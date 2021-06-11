using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.Configuration
{
    public class OrderTypeConfiguration : IEntityTypeConfiguration<OrderType>
    {
        public void Configure(EntityTypeBuilder<OrderType> builder)
        {
            builder.HasKey(x => x.code);
            builder.Property(x => x.name)
                .HasMaxLength(1000);
            builder.Property(x => x.shortName)
                .HasMaxLength(1000);
            builder.Property(x => x.note)
                .HasMaxLength(1000);
            builder.Property(x => x.createdAt)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now);
            builder.Property(x => x.lastUpdatedAt)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now);

            builder.HasData(new OrderType() 
            { 
                code = "topup",
                name = "Nạp tiền điện thoại",
                shortName = "Nạp tiền điện thoại",
                note = "TEST"
            });

            builder.HasData(new OrderType()
            {
                code = "billpayment",
                name = "Thanh toán hóa đơn",
                shortName = "Thanh toán hóa đơn",
                note = "TEST"
            });

            builder.HasData(new OrderType()
            {
                code = "fashion",
                name = "Thời trang",
                shortName = "Thời trang",
                note = "TEST"
            });

            builder.HasData(new OrderType()
            {
                code = "other",
                name = "Thanh toán trực tuyến",
                shortName = "Thanh toán trực tuyến",
                note = "TEST"
            });
        }
    }
}
