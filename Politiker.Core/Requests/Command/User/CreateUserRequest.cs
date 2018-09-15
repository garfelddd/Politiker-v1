using AutoMapper;
using Kernel.CQRS.Command;
using Politiker.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Requests.Command.User
{
    public class CreateUserRequest : ICommand, IMap
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public UserRole UserRole { get; set; }

        public void Mapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<CreateUserRequest, Entity.User>();
        }

        public void SetSalt(string salt)
        {
            Salt = salt;
        }
        public void SetHashPassword(string password)
        {
            Password = password;
        }
        //
        public void SetRole(UserRole role)
        {
            UserRole = role;
        }
    }
}
