using System;
using System.Collections.Generic;
using System.Text;

namespace Kernel.CQRS
{
    public class HandlerNotFoundException : Exception
    {
        public HandlerNotFoundException(string message) : base(message)
        {
        }
    }
}
