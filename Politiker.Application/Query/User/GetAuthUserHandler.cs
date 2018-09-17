using Politiker.Core.Results.Query.User;
using System;
using System.Collections.Generic;
using System.Text;
using Kernel.CQRS.Query;
using Politiker.Core.Requests.Query.User;
using Politiker.Infrastructure;
using System.Linq;
using AutoMapper;

namespace Politiker.Application.Query.User
{
    public class GetAuthUserHandler : IQueryHandler<GetAuthUserRequest, BaseUserResult>
    {
        private readonly MainContext _context;

        public GetAuthUserHandler(MainContext context)
        {
            _context = context;
        }

        public BaseUserResult Execute(GetAuthUserRequest query)
        {
            var user = _context.Users.Single(x => (x.Login == query.Login));
            var userResult = Mapper.Map<BaseUserResult>(user);
            return userResult;
        }
    }
}
