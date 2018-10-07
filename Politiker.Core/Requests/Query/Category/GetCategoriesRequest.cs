using Kernel.CQRS.Query;
using Politiker.Core.Results.Query.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Requests.Query.Category
{
    public class GetCategoriesRequest : IQuery<CategoriesResult>
    {
        public string Name { get; set; }
    }
}
