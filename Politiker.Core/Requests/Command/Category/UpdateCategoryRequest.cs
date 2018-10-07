using AutoMapper;
using Kernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Requests.Command.Category
{
    public class UpdateCategoryRequest : IMap, ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<UpdateCategoryRequest, Core.Entity.Category>();
        }
    }

}
