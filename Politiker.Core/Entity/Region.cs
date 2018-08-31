using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Entity
{
    public class Region : BaseEntity
    {
        public string Name { get; set; }
        public string EngName { get; set; }
        public string GraphPath { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
