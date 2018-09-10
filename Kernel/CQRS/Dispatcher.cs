using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
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

        public TResult ExecuteQuery<TResult>(IQuery<TResult> query) where TResult : IQueryResult
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }
            Type[] genericTypes = { query.GetType(), typeof(TResult)};
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(genericTypes);
            System.Diagnostics.Debug.WriteLine("Dupa"+ handlerType.FullName);
            //dynamic handler = _provider.GetService<IQueryHandler<TQuery, TResult>>();
            dynamic handler = _provider.GetService(handlerType);
            if (handler == null)
            {
                throw new HandlerNotFoundException(handlerType.Name + " not found");
            }

            return handler.Execute((dynamic)query);

        }
        public void ExecuteCommand<TCommand>(TCommand command) where TCommand : ICommand
        {

            var genericType = command.GetType();
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(genericType);
            dynamic handler = _provider.GetService(handlerType);

            if (handler == null)
            {
                throw new HandlerNotFoundException(nameof(TCommand) + " not found");
            }

            handler.Execute(command);
        }
        
    }
}
