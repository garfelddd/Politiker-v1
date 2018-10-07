using Kernel.Validation;
using Politiker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Application.Validators
{
    public class CategoryValidationHandler : IValidationHandler
    {
        private readonly MainContext _context;

        public CategoryValidationHandler(MainContext context)
        {
            _context = context;
        }


    }
}
