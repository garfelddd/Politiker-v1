using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Entity
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string EngName { get; set; }
        public string Code { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public int RegionId { get; set; }
        public ICollection<Region> Regions { get; set; }
    }
}
