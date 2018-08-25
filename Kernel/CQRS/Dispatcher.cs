using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Kernel.CQRS.Command;
using Kernel.CQRS.Query;

namespace Kernel.CQRS
{
    public class Dispatcher
    {
        private readonly IServiceProvider _provider;

        public Dispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }
        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {


            var handler = _provider.GetService<ICommandHandler<TCommand>>();

            if (handler == null)
            {
                throw new HandlerNotFoundException(nameof(TCommand) + " not found");
            }

            handler.Execute(command);
        }

        public TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            var handler = _provider.GetService<IQueryHandler<TQuery, TResult>>();

            if (handler == null)
            {
                throw new HandlerNotFoundException(nameof(TQuery) + " not found");
            }

            return handler.Execute(query);

        }
    }
}
