using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Politiker.Core.Entity;

namespace Politiker.Infrastructure.Map
{
    public class RegionMap : IEntityTypeConfiguration<Region>, ISeedTable<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("Regions");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.GraphPath)
                .HasColumnType("text");

            builder.HasOne(x => x.Country)
                .WithMany(x => x.Regions)
                .HasForeignKey(x => x.CountryId);

            builder.HasData(Seed());
        }

        public Region[] Seed()
        {
            return new Region[]
            {
                new Region { Id = 1, Name = "dolnośląskie", EngName = "", CountryId = 1},
                new Region { Id = 2, Name = "kujawsko-pomorskie", EngName = "", CountryId = 1},
                new Region { Id = 3, Name = "lubelskie", EngName = "", CountryId = 1},
                new Region { Id = 4, Name = "lubuskie", EngName = "", CountryId = 1},
                new Region { Id = 5, Name = "łódzkie", EngName = "", CountryId = 1},
                new Region { Id = 6, Name = "małopolskie", EngName = "", CountryId = 1},
                new Region { Id = 7, Name = "mazowieckie", EngName = "", CountryId = 1},
                new Region { Id = 8, Name = "opolskie", EngName = "", CountryId = 1},
                new Region { Id = 9, Name = "podkarpackie", EngName = "", CountryId = 1},
                new Region { Id = 10, Name = "podlaskie", EngName = "", CountryId = 1},
                new Region { Id = 11, Name = "pomorskie", EngName = "", CountryId = 1},
                new Region { Id = 12, Name = "śląskie", EngName = "", CountryId = 1},
                new Region { Id = 13, Name = "świętokrzyskie", EngName = "", CountryId = 1},
                new Region { Id = 14, Name = "warmińsko-mazurskie", EngName = "", CountryId = 1},
                new Region { Id = 15, Name = "wielkopolskie", EngName = "", CountryId = 1},
                new Region { Id = 16, Name = "zachodniopomorskie", EngName = "", CountryId = 1}
            };
        }
    }
}
