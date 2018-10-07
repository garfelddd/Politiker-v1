using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Kernel.CQRS.Query;
using Kernel.CQRS;
using Politiker.Core.Requests.Query.Regions;
using Politiker.Core.Results.Query.Regions;
using Politiker.Infrastructure;

namespace Politiker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly Dispatcher _dispatcher;

        public RegionController(Dispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("getbyname/{name}")]
        public ActionResult<List<string>> GetRegionsByName([FromRoute] string name)
        {
            var regionsResult = _dispatcher.ExecuteQuery(new GetRegionsByCountryRequest { CountryName = name });
            return regionsResult.Select(x => x.Name).ToList();
        }


    }
}