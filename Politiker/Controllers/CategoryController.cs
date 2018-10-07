using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kernel.CQRS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Politiker.Core.Requests.Command.Category;
using Politiker.Core.Requests.Query.Category;
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

        [HttpGet("list")]
        public IActionResult List()
        {
            var categories = _dispatcher.ExecuteQuery(new GetCategoriesRequest());
            return Ok(categories);
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var categoryRequest = new GetCategoryByIdRequest(id);
            var categoryResult = _dispatcher.ExecuteQuery(categoryRequest);
            return Ok(categoryResult);
        }

        [HttpDelete("removebyid/{id}")]
        public IActionResult RemoveById([FromRoute] int id)
        {
            var categoryRequest = new RemoveCategoryByIdRequest(id);
            _dispatcher.ExecuteCommand(categoryRequest);
            return Ok();
        }


        [HttpPut("update")]
        public IActionResult Update([FromBody]UpdateCategoryRequest category)
        {
            _dispatcher.ExecuteCommand(category);
            return Ok();
        }

    }
}