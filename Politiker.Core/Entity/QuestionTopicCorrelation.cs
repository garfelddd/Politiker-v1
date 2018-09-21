using Politiker.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Politiker.Core.Entity
{
    public class QuestionTopicCorrelation : BaseEntity
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public Topic Topic { get; set; }

        [Range(0,3, ErrorMessage = "Wartosc musi byc pomiedzy 1 a 3")]
        public byte ImportanceValue { get; set; }
    }
}
