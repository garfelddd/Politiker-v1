using System;
using System.Collections.Generic;
using System.Text;

namespace Kernel.CQRS.Query
{
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult> where TResult : IQueryResult
    {
        TResult Execute(TQuery query);
    }
}
