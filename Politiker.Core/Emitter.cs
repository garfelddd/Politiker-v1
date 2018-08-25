using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Politiker.Core
{
    public class Emitter
    {
        public static List<Type> MapperClasses() => Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(
                x => x.IsClass &&
                     typeof(IMap).IsAssignableFrom(x)
                )
            .ToList();
            
    }
}