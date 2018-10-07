using Kernel.CQRS.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Results.Query.Category
{
    public class CategoriesResult : List<CategoryResult>, IQueryResult
    {
        public CategoriesResult(IEnumerable<CategoryResult> collection) : base(collection)
        {
        }
    }
}
