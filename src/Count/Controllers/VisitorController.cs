using Count.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Count.Controllers
{
    [Route("api/[controller]")]
    public class VisitorController : Controller
    {
        private readonly IVisitorRepository _visitorRepository;
        private readonly ILogger _logger;

        public VisitorController(IVisitorRepository todoRepository, ILogger<VisitorController> logger)
        {
            _visitorRepository = todoRepository;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<VisitorItem> GetAll()
        {
            return _visitorRepository.GetAll();
        }

        [HttpGet("last")]
        public IActionResult GetLast()
        {
            var list = _visitorRepository.GetAll();

            if(list.Count() == 0)
            {
                return new NoContentResult();
            }
            else
            {
                return new ObjectResult(list.Last());
            }
        }

        [HttpGet("{id}", Name = "GetVisitor")]
        public IActionResult GetById(long id)
        {
            var item = _visitorRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] VisitorItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _visitorRepository.Add(item);
            _logger.LogInformation(1000, "Visit {ID} visitors.", item.Key);

            return CreatedAtRoute("GetVisitor", new { id = item.Key }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] VisitorItem item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var visitor = _visitorRepository.Find(id);
            if (visitor == null)
            {
                return NotFound();
            }
            
            visitor.IPAddress = item.IPAddress;
            visitor.Referer = item.Referer;

            _visitorRepository.Update(visitor);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var visitor = _visitorRepository.Find(id);
            if (visitor == null)
            {
                return NotFound();
            }

            _visitorRepository.Remove(id);
            return new NoContentResult();
        }
    }
}
