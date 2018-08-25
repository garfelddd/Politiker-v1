using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Politiker.Core
{
    public interface IMap
    {
        void Mapping(IMapperConfigurationExpression config);
    }
}
