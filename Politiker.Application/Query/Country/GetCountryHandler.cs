using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Kernel.CQRS.Query;
using Politiker.Core;
using Politiker.Core.Requests.Query.Country;
using Politiker.Core.Results.Query.Country;
using Politiker.Infrastructure;

namespace Politiker.Application.Query.Country
{
    public class GetCountryHandler : IQueryHandler<GetCountryByNameOrIdRequest, CountryResult>
    {
        private readonly MainContext _context;

        public GetCountryHandler(MainContext context)
        {
            _context = context;
        }

        public CountryResult Execute(GetCountryByNameOrIdRequest query)
        {
            //var country = _context.Set<Core.Entity.Country>().SingleOrDefault(x => (x.Id == query.Id || x.Name == query.Name));
            var country = _context.Countries.FirstOrDefault();
            return Mapper.Map<CountryResult>(country);
        }
    }
}
