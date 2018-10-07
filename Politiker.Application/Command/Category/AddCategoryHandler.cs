using Kernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Text;
using Politiker.Core.Requests.Command.Category;
using Politiker.Infrastructure;
using AutoMapper;

namespace Politiker.Application.Command.Category
{
    public class AddCategoryHandler : ICommandHandler<AddCategoryRequest>
    {
        private readonly MainContext _context;

        public AddCategoryHandler(MainContext context)
        {
            _context = context;
        }

        public void Execute(AddCategoryRequest command)
        {
            _context.Add(Mapper.Map<Core.Entity.Category>(command));
            _context.SaveChanges();
        }
    }
}
