using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using Autofac;
using Kernel.CQRS.Query;
using Kernel.CQRS.Command;
using Kernel.Validation;

namespace Politiker.Application.Modules
{
    public class ApplicationDiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var asm = Assembly.GetExecutingAssembly();
            var queryHandlersTypes = asm.GetTypes().Where(x => x.GetInterfaces().Any(y => y.IsGenericType && ( y.GetGenericTypeDefinition() == (typeof(IQueryHandler<,>)) || y.GetGenericTypeDefinition() == typeof(ICommandHandler<>)) ) && x.IsClass);
            foreach(var type in queryHandlersTypes)
            {
                foreach (var interfaceType in type.GetInterfaces())
                {
                    var genericType = interfaceType.GetGenericTypeDefinition();
                    if (genericType == typeof(IQueryHandler<,>))
                    {
                        var iType = typeof(IQueryHandler<,>).MakeGenericType(interfaceType.GetGenericArguments());
                        builder.RegisterType(type).As(iType).InstancePerLifetimeScope();
                        
                    }
                    if(genericType == typeof(ICommandHandler<>))
                    {
                        var iType = typeof(ICommandHandler<>).MakeGenericType(interfaceType.GetGenericArguments()[0]);
                        builder.RegisterType(type).As(iType).InstancePerLifetimeScope();
                    }
                }
            }

            //Register all validations handlers
            builder.RegisterAssemblyTypes(asm)
               .Where(x => typeof(IValidationHandler).IsAssignableFrom(x))
               .AsSelf()
               .InstancePerLifetimeScope();
        }
    }
}
