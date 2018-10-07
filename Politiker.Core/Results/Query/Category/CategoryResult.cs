using AutoMapper;
using Kernel.CQRS.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Results.Query.Category
{
    public class CategoryResult : IMap, IQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<Entity.Category, CategoryResult>();
        }
    }
}
