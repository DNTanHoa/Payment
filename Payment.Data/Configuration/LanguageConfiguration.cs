using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payment.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Data.Configuration
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.code);
            builder.Property(x => x.name)
                .HasMaxLength(500);
            builder.HasData(new Language
            {
                code = "en",
                name = "English"
            });
            builder.HasData(new Language
            {
                code = "vn",
                name = "Việt Nam"
            });
        }
    }
}
