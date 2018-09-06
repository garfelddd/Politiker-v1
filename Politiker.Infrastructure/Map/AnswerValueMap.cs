using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Politiker.Core.Entity;

namespace Politiker.Infrastructure.Map
{
    public class AnswerValueMap : IEntityTypeConfiguration<AnswerValue>
    {
        public void Configure(EntityTypeBuilder<AnswerValue> builder)
        {
            builder.ToTable("AnswerValues");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Answer)
                .WithMany(x => x.AnswerValues)
                .HasForeignKey(x => x.AnswerId);

            builder.HasOne(x => x.AnswerTopic)
                .WithMany(x => x.AnswerValues)
                .HasForeignKey(x => x.AnswerTopicId);
        }
    }
}
