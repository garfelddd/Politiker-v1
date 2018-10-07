using Kernel.CQRS.Query;
using Politiker.Core.Requests.Query.Category;
using Politiker.Core.Results.Query.Category;
using Politiker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;

namespace Politiker.Application.Query.Category
{
    public class GetCategoriesHandler : IQueryHandler<GetCategoriesRequest, CategoriesResult>
    {
        private readonly MainContext _context;

        public GetCategoriesHandler(MainContext context)
        {
            _context = context;
        }

        public CategoriesResult Execute(GetCategoriesRequest query)
        {
            List<CategoryResult> categories = _context.Categories.Select(x => Mapper.Map<CategoryResult>(x)).ToList();
            return new CategoriesResult(categories);
        }
    }
}
