using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TimestampMicroservice.Controllers
{
    [Route("/api/[controller]/")]
    [ApiController]
    public class TimestampController : ControllerBase
    {
        // GET api/timestamp
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/timestamp/1450137600
        [HttpGet("{datetime}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}
