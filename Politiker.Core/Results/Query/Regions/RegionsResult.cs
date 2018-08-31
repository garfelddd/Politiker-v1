using System;
using System.Collections.Generic;
using System.Text;
using Kernel.CQRS.Query;

namespace Politiker.Core.Results.Query.Regions
{
    public class RegionsResult : List<RegionResult>, IQueryResult
    {
        public RegionsResult(IEnumerable<RegionResult> collection) : base(collection)
        {
        }
    }
}
