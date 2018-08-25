using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Entity
{
    public class Party : BaseEntity
    {
        public string Name { get; set; }
        public string President { get; set; }
        public string Image { get; set; }

    }
}
