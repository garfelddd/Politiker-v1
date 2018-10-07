using Kernel.CQRS.Command;
using Politiker.Core.Requests.Command.Category;
using Politiker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Politiker.Application.Command.Category
{
    public class RemoveCategoryByIdHandler : ICommandHandler<RemoveCategoryByIdRequest>
    {
        public MainContext _context;

        public RemoveCategoryByIdHandler(MainContext context)
        {
            _context = context;
        }

        public void Execute(RemoveCategoryByIdRequest command)
        {
            var category =_context.Categories.Single(x => x.Id == command.Id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
