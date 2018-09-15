using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kernel.CQRS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Politiker.Core.Requests.Command.User;
using Politiker.Extensions;
using Politiker.Filters;

namespace Politiker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Dispatcher _dispatcher;

        public UserController(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        // POST api/user/register
        [HttpPost("register")]
        [ValidatorActionFilter]
        public IActionResult Register([FromBody] CreateUserRequest userRequest)
        {
            /*if (!ModelState.IsValid)
            {
                var errorList = ModelState.SelectErrorMessages();
                return BadRequest(errorList);
            }
            */
            _dispatcher.ExecuteCommand(userRequest);
            

            return Ok();

        }


    }
}