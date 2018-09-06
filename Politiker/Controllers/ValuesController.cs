using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ValuesController : ControllerBase
    {

        private readonly Dispatcher _dispatcher;

        public ValuesController(Dispatcher dispatcher)
        {

            _dispatcher = dispatcher;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<RegionsResult> Get()
        {
            var regionsResult = _dispatcher.Execute<GetRegionsByCountryRequest, RegionsResult>(new GetRegionsByCountryRequest { CountryName = "Polska"});
            return regionsResult;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
