using Kernel.CQRS.Query;
using Politiker.Core.Results.Query.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Requests.Query.Category
{
    public class GetCategoryByIdRequest : IQuery<CategoryResult>
    {
        public int Id { get; set; }

        public GetCategoryByIdRequest(int id)
        {
            Id = id;
        }
    }
}
