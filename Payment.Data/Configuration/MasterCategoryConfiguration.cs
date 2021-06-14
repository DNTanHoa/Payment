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
    public class MasterCategoryConfiguration : IEntityTypeConfiguration<MasterCategory>
    {
        public void Configure(EntityTypeBuilder<MasterCategory> builder)
        {
            builder.HasKey(x => x.code);
            builder.Property(x => x.group)
                .HasMaxLength(100);
            builder.Property(x => x.name)
                .HasMaxLength(1000);
            builder.Property(x => x.description)
                .HasMaxLength(1000);
            builder.Property(x => x.value)
                .HasMaxLength(100);

        }
    }
}
