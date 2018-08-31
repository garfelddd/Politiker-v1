using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Kernel.CQRS.Query;
using Politiker.Core;

namespace Politiker.Core.Results.Query.Country
{
    public class CountryResult : IQueryResult, IMap
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public void Mapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<CountryResult, Entity.Country>();
        }
    }
}
