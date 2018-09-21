using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kernel.CQRS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Politiker.Core.Requests.Command.Category;
using Politiker.Filters;

namespace Politiker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Dispatcher _dispatcher;

        public CategoryController(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpPost("add")]
        [ValidatorActionFilter]
        public IActionResult Add(AddCategoryRequest category)
        {
            _dispatcher.ExecuteCommand(category);

            return Ok();
        }
    }
}