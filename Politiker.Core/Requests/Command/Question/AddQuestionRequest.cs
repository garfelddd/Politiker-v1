using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Kernel.CQRS.Command;
using Politiker.Core.Entity;
using Politiker.Core.Enum;

namespace Politiker.Core.Requests.Command.Question
{
    public class AddQuestionRequest : IMap, ICommand
    {
        public Dictionary<Topic, byte> Topics { get; set; }
        public string RealQuestion { get; private set; }

        public void Mapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<AddQuestionRequest, Entity.Question>();
        }
    }
}
