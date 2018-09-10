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
        [HttpGet("{time}")]
        public ActionResult<DateTimeResult> Get(string time)
        {
          DateTimeResult Result = new DateTimeResult(time);
          return Result;
        }

        public class DateTimeResult {
          public decimal Unix { get; set; }
          public string Natural { get; set; }
          
          public DateTimeResult(string time) 
          {
            var isNumeric = int.TryParse(time, out int n);

            if(isNumeric)
            {
              // Unix -> Decimal
              Unix = decimal.Parse(time); 
              
              // Unix -> Date -> String
              DateTimeOffset parsedDate = DateTimeOffset.FromUnixTimeSeconds(long.Parse(time));
              Natural = parsedDate.ToString();
            }
            else
            {
              // String -> Date -> Unix
              DateTimeOffset dateTimeOffset = DateTimeOffset.Parse(time);
              Unix = dateTimeOffset.ToUnixTimeMilliseconds();

              // String -> Date -> String
              DateTimeOffset parsedDate = DateTimeOffset.Parse(time);
              Natural = parsedDate.ToString();
            }
          }
        }
    }
}
