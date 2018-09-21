using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Politiker.Core.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Politiker.Infrastructure.Map
{
    class QuestionTopicCorellationMap : IEntityTypeConfiguration<QuestionTopicCorrelation>
    {
        public void Configure(EntityTypeBuilder<QuestionTopicCorrelation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("QuestionTopic");

            builder.HasOne(x => x.Question)
                .WithMany(x => x.Topics)
                .HasForeignKey(x => x.QuestionId);
        }
    }
}
