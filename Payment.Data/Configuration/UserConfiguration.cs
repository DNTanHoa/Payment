using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.username);
            builder.Property(x => x.password)
                .HasMaxLength(1000);
            builder.Property(x => x.hashkey)
                .HasMaxLength(1000);
        }
    }
}
