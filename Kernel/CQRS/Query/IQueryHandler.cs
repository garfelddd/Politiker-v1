using System;
using System.Collections.Generic;
using System.Text;

namespace Kernel.CQRS.Query
{
    interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        TResult Execute(TQuery query);
    }
}
