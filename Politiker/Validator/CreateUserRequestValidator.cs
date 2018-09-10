using FluentValidation;
using Politiker.Core.Requests.Command.User;
using Politiker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Politiker.Validator
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        private readonly MainContext _context;
        public CreateUserRequestValidator(MainContext context)
        {
            _context = context;
            RuleFor(x => x.Login).Must(LoginExists).WithMessage("The login already exists in our database");
            RuleFor(x => x.Email).Must(EmailExists).WithMessage("The email already exists in our database");
        }

        public bool LoginExists(string login)
        {
            System.Diagnostics.Debug.WriteLine(_context.Users.Any(x => x.Login == login)+ "login dziala");
            return !_context.Users.Any(x => x.Login == login);
        }
        public bool EmailExists(string email)
        {
            System.Diagnostics.Debug.WriteLine(_context.Users.Any(x => x.Email == email) + "email dziala");
            return !_context.Users.Any(x => x.Email == email);
        }
    }
}
