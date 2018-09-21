using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Kernel.CQRS.Command;

namespace Politiker.Core.Requests.Command.Category
{
    public class AddCategoryRequest : ICommand, IMap
    {
        public void Mapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<AddCategoryRequest, Entity.Category>();
        }
    }
}
