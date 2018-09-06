using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Politiker.Core.Entity;

namespace Politiker.Infrastructure.Map
{
    public class AnswerTopicMap : IEntityTypeConfiguration<AnswerTopic>
    {
        public void Configure(EntityTypeBuilder<AnswerTopic> builder)
        {
            builder.ToTable("AnswerTopics");
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.AnswerValues)
                .WithOne(x => x.AnswerTopic)
                .HasForeignKey(x => x.AnswerTopicId);
        }
    }
}
