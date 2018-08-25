using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Entity
{
    public class Answer : BaseEntity
    {
        public string RealAnswer { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
