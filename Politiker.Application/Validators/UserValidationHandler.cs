using Kernel.Validation;
using Politiker.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Utils.Security.PasswordHashService;
using Politiker.Core;

namespace Politiker.Application.Validators
{
    public class UserValidationHandler : IValidationHandler
    {
        private readonly MainContext _context;

        public UserValidationHandler(MainContext context)
        {
            _context = context;
        }

        private Core.Entity.User GetUserByLogin(string login)
        {
            return _context.Users.SingleOrDefault(x => x.Login == login);
        }

        public bool LoginExists(string login)
        {
            return _context.Users.Any(x => x.Login == login);
        }
        public bool EmailExists(string email)
        {
            return _context.Users.Any(x => x.Email == email);
        }
        public bool ValidateAuth(string login, string password)
        {
            var user = GetUserByLogin(login);
            if(user != null)
            {
                bool verification = CompareHashes(password, user.Password, user.Salt);
                return verification;
            }
            return false;

        }
    }
}
