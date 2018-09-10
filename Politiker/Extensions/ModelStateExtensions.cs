using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Politiker.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> SelectErrorMessages(this ModelStateDictionary modelState)
        {
            return modelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
        }
    }
}
