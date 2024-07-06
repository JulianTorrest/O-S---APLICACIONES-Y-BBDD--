using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CustomerAccessControl.Models;
using CustomerAccessControl.Services;

namespace CustomerAccessControl.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CenterController : ControllerBase
    {
        private readonly CenterService _centerService;
        private readonly EntryService _entryService;

        public CenterController(CenterService centerService, EntryService entryService)
        {
            _centerService = centerService;
            _entryService = entryService;
        }

        // GET: api/Center
        [HttpGet]
        public ActionResult<List<Center>> Get()
        {
            return _centerService.GetAllCenters();
        }

        // GET: api/Center/{id}
        [HttpGet("{id}", Name = "GetCenter")]
        public ActionResult<Center> Get(int id)
        {
            var center = _centerService.GetCenterById(id);

            if (center == null)
            {
                return NotFound();
            }

            return center;
        }

        // POST: api/Center
        [HttpPost]
        public ActionResult<Center> Create(Center center)
        {
            _centerService.CreateCenter(center);

            return CreatedAtRoute("GetCenter", new { id = center.Id }, center);
        }

        // PUT: api/Center/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Center centerIn)
        {
            var center = _centerService.GetCenterById(id);

            if (center == null)
            {
                return NotFound();
            }

            _centerService.UpdateCenter(id, centerIn);

            return NoContent();
        }

        // DELETE: api/Center/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var center = _centerService.GetCenterById(id);

            if (center == null)
            {
                return NotFound();
            }

            _centerService.DeleteCenter(center.Id);

            return NoContent();
        }

        // POST: api/Center/{id}/Entry
        [HttpPost("{id}/Entry")]
        public ActionResult<Entry> RegisterEntry(int id, Entry entry)
        {
            var center = _centerService.GetCenterById(id);

            if (center == null)
            {
                return NotFound();
            }

            entry.CenterId = center.Id;
            _entryService.RegisterEntry(entry);

            return Ok(entry);
        }
    }
}

