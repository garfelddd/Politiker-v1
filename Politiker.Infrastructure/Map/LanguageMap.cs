using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Politiker.Core.Entity;

namespace Politiker.Infrastructure.Map
{
    public class LanguageMap : IEntityTypeConfiguration<Language>, ISeedTable<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages");
            builder.HasKey(x => x.Id);

            builder.HasData(Seed());

            builder.HasMany(x => x.Countries)
                .WithOne(x => x.Language)
                .HasForeignKey(x => x.LanguageId);
        }

        public Language[] Seed()
        {
            return new Language[] {
                new Language { Id = 1, Name = "polski", EngName = "polish", Code = "pl" }
            };
        }
    }
}
