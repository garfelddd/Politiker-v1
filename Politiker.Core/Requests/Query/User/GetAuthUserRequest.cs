using Kernel.CQRS.Query;
using Politiker.Core.Results.Query.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Politiker.Core.Requests.Query.User
{
    public class GetAuthUserRequest : IQuery<BaseUserResult>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
