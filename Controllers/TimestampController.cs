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
        // GET api/timestamp/1450137600
        [HttpGet("{unix}")]
        public ActionResult<DateTimeResult> Get(string unix)
        {
          DateTimeResult Result = new DateTimeResult(unix);
          return Result;
        }

        public class DateTimeResult {
          public decimal Unix { get; set; }
          public string Natural { get; set; }
          
          public DateTimeResult(string unix) 
          {
            // Unix -> Decimal
            Unix = decimal.Parse(unix); 

            // Unix -> Date -> String
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(long.Parse(unix));
            Natural = dateTimeOffset.ToString("dd MMMM yyyy");
          }
        }
    }
}
