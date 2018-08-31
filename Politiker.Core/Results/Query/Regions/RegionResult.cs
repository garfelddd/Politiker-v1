using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Kernel.CQRS.Query;

namespace Politiker.Core.Results.Query.Regions
{
    public class RegionResult : IQueryResult, IMap
    {
        public string Name { get; set; }
        public string EngName { get; set; }
        public string GraphPath { get; set; }

        public void Mapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<RegionResult, Entity.Region>();
        }
    }
}
