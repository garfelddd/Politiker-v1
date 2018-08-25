using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Politiker.Core.Entity;

namespace Politiker.Infrastructure.Map
{
    class PartyMap : IEntityTypeConfiguration<Party>
    {
        public void Configure(EntityTypeBuilder<Party> builder)
        {
            builder.ToTable("Party");
            builder.HasKey(x => x.Id);
        }
    }
}
