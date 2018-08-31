using System;
using System.Collections.Generic;
using System.Text;
using Kernel.CQRS.Query;
using Politiker.Core.Results.Query.Regions;

namespace Politiker.Core.Requests.Query.Regions
{
    public class GetRegionsByCountryRequest : IQuery<RegionsResult>
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
