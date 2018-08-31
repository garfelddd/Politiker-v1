using System;
using System.Collections.Generic;
using System.Text;
using Kernel.CQRS.Query;
using Politiker.Core.Results.Query.Country;

namespace Politiker.Core.Requests.Query.Country
{
    public class GetCountryByNameOrIdRequest : IQuery<CountryResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
