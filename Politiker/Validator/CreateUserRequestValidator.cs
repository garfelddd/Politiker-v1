using FluentValidation;
using Politiker.Application.Validators;
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
        private readonly UserValidationHandler _handler;
        public CreateUserRequestValidator(UserValidationHandler handler)
        {
            _handler = handler;
            RuleFor(x => x.Login).Must(x => !_handler.LoginExists(x)).WithMessage("Login juz istnieje w bazie");
            RuleFor(x => x.Email).Must(x => !_handler.EmailExists(x)).WithMessage("Email juz istnieje w bazie");
        }
    }
}
