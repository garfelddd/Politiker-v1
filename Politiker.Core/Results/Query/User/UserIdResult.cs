using Kernel.CQRS.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Results.Query.User
{
    public class UserIdResult : IQueryResult
    {
        public int Id { get; set; }
    }
}
