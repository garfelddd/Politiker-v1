using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Entity
{
    public class AnswerValue : BaseEntity
    {
        public int Value { get; set; }

        public int AnswerId { get; set; }
        public Answer Answer { get; set; }

        public int AnswerTopicId { get; set; }
        public AnswerTopic AnswerTopic { get; set; }
    }
}
