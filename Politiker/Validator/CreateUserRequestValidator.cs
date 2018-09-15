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
            RuleFor(x => x.Login).Must(LoginExists).WithMessage("Login juz istnieje w bazie");
            RuleFor(x => x.Email).Must(EmailExists).WithMessage("Email juz istnieje w bazie");
        }

        public bool LoginExists(string login)
        {
            return !_context.Users.Any(x => x.Login == login);
        }
        public bool EmailExists(string email)
        {
            return !_context.Users.Any(x => x.Email == email);
        }
    }
}
