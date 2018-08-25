using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Kernel.CQRS.Command;

namespace Politiker.Core.Requests.Command.Question
{
    public class AddQuestionRequest : IMap, ICommand
    {
        public string Question { get; private set; }
        public int CategoryId { get; private set; }

        public void Mapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<AddQuestionRequest, Entity.Question>();
        }
    }
}
