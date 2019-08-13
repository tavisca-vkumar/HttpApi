using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HttpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Hello";
        }

        // GET api/values/5
        [HttpGet("{message}")]
        public ActionResult<string> Get(string message)
        {
            switch(message)
            {
                case "hi":
                    return "hello";
                    
                case "hello":
                    return "hi";
                    
                default:
                    return "don't understand";
                    
            }
            
        }


        
    }
}
