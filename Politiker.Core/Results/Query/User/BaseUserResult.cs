using AutoMapper;
using Kernel.CQRS.Query;
using Politiker.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Results.Query.User
{
    public class BaseUserResult : IQueryResult, IMap
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public UserRole UserRole { get; set; }

        public void Mapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<Entity.User, BaseUserResult>();
        }
    }
}
