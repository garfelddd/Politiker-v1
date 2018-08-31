using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Entity
{
    public class Language : BaseEntity
    {
        public string Name { get; set; }
        public string EngName { get; set; }
        public string Code { get; set; }

        public ICollection<Country> Countries { get; set; }

    }
}
