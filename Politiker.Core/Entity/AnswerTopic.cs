using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Entity
{
    public class AnswerTopic : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LeftTitle { get; set; }
        public string RightTitle { get; set; }

        public ICollection<AnswerValue> AnswerValues { get; set; }
    }
}
