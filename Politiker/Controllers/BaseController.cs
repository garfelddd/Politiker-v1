using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kernel.CQRS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Politiker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}