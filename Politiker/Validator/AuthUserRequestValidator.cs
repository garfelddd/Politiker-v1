using FluentValidation;
using Politiker.Application.Validators;
using Politiker.Core.Requests.Query.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Politiker.Validator
{
    public class AuthUserRequestValidator : AbstractValidator<GetAuthUserRequest>
    {
        private UserValidationHandler _handler;

        public AuthUserRequestValidator(UserValidationHandler handler)
        {
            _handler = handler;

            RuleFor(x => x).Must(x => _handler.ValidateAuth(x.Login, x.Password)).WithMessage("Dane nieprawidlowe");
        }
    }
}
