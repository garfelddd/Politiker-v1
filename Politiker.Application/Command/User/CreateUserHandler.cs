using AutoMapper;
using Kernel.CQRS.Command;
using Politiker.Core.Enum;
using Politiker.Core.Requests.Command.User;
using Politiker.Infrastructure;
using static Utils.Security.PasswordHashService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Application.Command.User
{
    public class CreateUserHandler : ICommandHandler<CreateUserRequest>
    {
        private readonly MainContext _context;

        public CreateUserHandler(MainContext context)
        {
            _context = context;
        }

        public void Execute(CreateUserRequest command)
        {
            //Setting role
            if (command.UserRole == 0)
            {
                command.SetRole(UserRole.Moderator);
            }
            //Setting salt
            var salt = GenerateSalt();
            command.SetSalt(salt);
            //Setting hashed password
            var hashPassword = GenerateHash(command.Password, salt);
            command.SetHashPassword(hashPassword);
            //Adding user
            _context.Users.Add(Mapper.Map<Core.Entity.User>(command));
            _context.SaveChanges();
        }
    }
}
