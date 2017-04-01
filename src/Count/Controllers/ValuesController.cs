using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Count.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        List<string> values = new List<string>();

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return values.ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return /*values[id]*/"Get";
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]string value)
        {
            Debug.WriteLine("Post invoked: value is " + value == "");
            values.Add(value);
            return "Success";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
