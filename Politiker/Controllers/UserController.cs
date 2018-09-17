using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Kernel.CQRS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Politiker.Core.Engine;
using Politiker.Core.Enum;
using Politiker.Core.Requests.Command.User;
using Politiker.Core.Requests.Query.User;
using Politiker.Extensions;
using Politiker.Filters;

namespace Politiker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Dispatcher _dispatcher;
        private readonly JwtOptions _jwtOptions;

        public UserController(Dispatcher dispatcher, JwtOptions jwtOptions)
        {
            _dispatcher = dispatcher;
            _jwtOptions = jwtOptions;
        }
        // POST api/user/register
        [HttpPost("register")]
        [ValidatorActionFilter]
        public IActionResult Register([FromBody] CreateUserRequest userRequest)
        {
            /*
            if (!ModelState.IsValid)
            {
                var errorList = ModelState.SelectErrorMessages();
                return BadRequest(errorList);
            }
            */
            
            _dispatcher.ExecuteCommand(userRequest);
            

            return Ok();

        }

        [HttpPost("login")]
        [ValidatorActionFilter]
        public IActionResult Login([FromBody] GetAuthUserRequest userRequest)
        {
            var userResult = _dispatcher.ExecuteQuery(userRequest);
            var tokenResult = GetJwtToken(userResult.Id, userResult.Login, userResult.UserRole);
            return Ok(new { Token = tokenResult});
        }

        private string GetJwtToken(int id, string login, UserRole userRole)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, id.ToString()),
                new Claim(ClaimTypes.Name, login),
                new Claim(ClaimTypes.Role, userRole.ToString())
            };

            var tokenOptions = new JwtSecurityToken(
           claims: claims,
           expires: DateTime.Now.AddMinutes(_jwtOptions.Expires),
           signingCredentials: _jwtOptions.SigningCredentials
           );

           var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
           return token;
        }
    }
}