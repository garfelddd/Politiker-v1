using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AutoMapper;
using Politiker.Infrastructure;
using Kernel.CQRS.Query;
using Politiker.Core.Requests.Query.Regions;
using Politiker.Core.Results.Query.Regions;

namespace Politiker.Application.Query.Region
{
    public class GetRegionsHandler : IQueryHandler<GetRegionsByCountryRequest, RegionsResult>
    {
        private readonly MainContext _context;

        public GetRegionsHandler(MainContext context)
        {
            _context = context;
        }

        public RegionsResult Execute(GetRegionsByCountryRequest query)
        {
            List<RegionResult> regions = _context.Regions.Where(x => (x.Country.Id == query.CountryId || x.Country.Name == query.CountryName)).Select(x => Mapper.Map<RegionResult>(x)).ToList();

            return new RegionsResult(regions);
        }
    }
}
