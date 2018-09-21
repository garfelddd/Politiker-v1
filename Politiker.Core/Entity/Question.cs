using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Entity
{
    public class Question : BaseEntity
    {
        public string RealQuestion { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Answer> Answers { get; set; }
        public ICollection<QuestionTopicCorrelation> Topics { get; set; }
    }
}
