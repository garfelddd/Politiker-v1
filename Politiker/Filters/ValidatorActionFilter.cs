using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Politiker.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Politiker.Filters
{
    public class ValidatorActionFilter : ActionFilterAttribute
    {
        private readonly bool _onlyErrors;

        public ValidatorActionFilter(bool onlyErrors = true)
        {
            _onlyErrors = onlyErrors;
        }


        public override void OnActionExecuting(ActionExecutingContext context)
        {
            object result;
            if(_onlyErrors)
            {
                result = context.ModelState.SelectErrorMessages();
            }
            else
            {
                result = context.ModelState;
            }
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(result);
            }
        }
    }
}
