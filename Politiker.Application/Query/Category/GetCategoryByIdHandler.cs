using AutoMapper;
using Kernel.CQRS.Query;
using Politiker.Core.Requests.Command.Category;
using Politiker.Core.Requests.Query.Category;
using Politiker.Core.Results.Query.Category;
using Politiker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Politiker.Application.Query.Category
{
    public class GetCategoryByIdHandler : IQueryHandler<GetCategoryByIdRequest, CategoryResult>
    {
        private MainContext _context;

        public GetCategoryByIdHandler(MainContext context)
        {
            _context = context;
        }

        public CategoryResult Execute(GetCategoryByIdRequest query)
        {
            var category = _context.Categories.Single(x => x.Id == query.Id);
            return Mapper.Map<CategoryResult>(category);
        }
    }
}
