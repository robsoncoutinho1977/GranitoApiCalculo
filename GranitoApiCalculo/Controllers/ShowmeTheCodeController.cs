using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GranitoApiCalculo.Controllers
{
    [Route("granito/[controller]")]
    [ApiController]
    public class ShowmeTheCodeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "value1";
        }
    }
}
