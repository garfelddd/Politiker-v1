using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Politiker.Core;

namespace Politiker.Modules
{
    public class AutoMapperConfiguration
    {
        private List<Type> _types { get; set; }

        public static AutoMapperConfiguration Register(List<Type> types)
        {
            return new AutoMapperConfiguration { _types = types};
        }

        private void CustomMapping(IMapperConfigurationExpression config)
        {
            foreach (var type in _types)
            {
                var instance = (IMap)Activator.CreateInstance(type);
                instance.Mapping(config);
            }
        }

        public void Initialize()
        {
            Mapper.Initialize(config =>
            {
                CustomMapping(config);
            });
        }

    }
}
