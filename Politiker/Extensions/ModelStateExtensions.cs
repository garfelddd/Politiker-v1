using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

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
