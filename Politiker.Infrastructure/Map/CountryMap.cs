using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Politiker.Core;
using Politiker.Core.Entity;

namespace Politiker.Infrastructure.Map
{
    public class CountryMap : IEntityTypeConfiguration<Country>, ISeedTable<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Language)
                .WithMany(x => x.Countries)
                .HasForeignKey(x => x.LanguageId);

            builder.HasData(Seed());
        }

        public Country[] Seed()
        {
            return new Country[] {
                new Country { Id = 1, Name = "Polska", EngName = "Poland", Code = "POL", LanguageId = 1 }
            };
        }
    }
}
