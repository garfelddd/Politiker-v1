using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Entity
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
