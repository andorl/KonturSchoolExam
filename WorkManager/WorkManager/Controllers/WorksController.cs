using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkManager.Areas.Identity.Data;
using WorkManager.Models;

namespace WorkManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WorksController : ControllerBase
    {
        private readonly WorkManagerDbContext context;

        public WorksController(WorkManagerDbContext context)
        {
            this.context = context;
        }

        // GET: api/Works?offset=1&count=3&sort=priority&category=study
        [HttpGet]
        public IEnumerable<Work> GetWorks([FromQuery] WorkFilter filter)
        {
            var query = context.Works.Where(work => BelongsToCurrentUser(work));

            if (filter.Category != null)
            {
                query = query.Where(work => work.Category == filter.Category);
            }

            query = query
                .Skip(filter.Offset ?? 0)
                .Take(filter.Count ?? 0);

            switch (filter.SortBy)
            {
                case "priority":
                    return query.OrderBy(w => w.Priority);

                case "duration":
                    return query.OrderBy(w => w.Duration);

                case "difficulty":
                    return query.OrderBy(w => w.Difficulty);

                default:
                    return query;
            }
        }

        private bool BelongsToCurrentUser(Work work)
        {
            return work.User.UserName == User.Identity.Name;
        }

        // GET: api/Works/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWork([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var work = await context.Works.FindAsync(id);

            if (work == null)
            {
                return NotFound();
            }

            if (!BelongsToCurrentUser(work))
            {
                return Forbid();
            }

            return Ok(work);
        }

        // PUT: api/Works/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWork([FromRoute] int id, [FromBody] Work work)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != work.Id)
            {
                return BadRequest();
            }

            context.Entry(work).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Works
        [HttpPost]
        public async Task<IActionResult> PostWork([FromBody] Work work)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Works.Add(work);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetWork", new { id = work.Id }, work);
        }

        // DELETE: api/Works/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWork([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var work = await context.Works.FindAsync(id);
            if (work == null)
            {
                return NotFound();
            }

            if (!BelongsToCurrentUser(work))
            {
                return Forbid();
            }

            context.Works.Remove(work);
            await context.SaveChangesAsync();

            return Ok(work);
        }

        private bool WorkExists(int id)
        {
            return context.Works.Any(e => e.Id == id);
        }
    }

    public class WorkFilter
    {
        public int? Offset { get; set; }
        public int? Count { get; set; }
        public string SortBy { get; set; }
        public string Category { get; set; }
    }
}