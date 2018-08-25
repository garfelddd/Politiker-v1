using System;
using System.Collections.Generic;
using System.Text;

namespace Kernel.CQRS.Command
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
