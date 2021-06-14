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
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(x => x.code);
            builder.Property(x => x.name)
                .HasMaxLength(1000);

            builder.HasData(new Gender()
            {
                code = "M",
                name = "Nam"
            });

            builder.HasData(new Gender()
            {
                code = "F",
                name = "Nữ"
            });
        }
    }
}
