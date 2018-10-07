using AutoMapper;
using Kernel.CQRS.Command;
using Politiker.Core.Requests.Command.Category;
using Politiker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Application.Command.Category
{
    public class UpdateCategoryHandler : ICommandHandler<UpdateCategoryRequest>
    {
        private MainContext _context;

        public UpdateCategoryHandler(MainContext context)
        {
            _context = context;
        }

        public void Execute(UpdateCategoryRequest command)
        {
            _context.Categories.Update(Mapper.Map<Core.Entity.Category>(command));
            _context.SaveChanges();
        }
    }
}
