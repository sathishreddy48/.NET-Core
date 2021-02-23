using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTask;
using WebApiTask.Models;

namespace WebApiTask.Controllers
{
    [Route("api/Tags")]
    [ApiController]
    public class TagsDBEntitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TagsDBEntitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TagsDBEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tags>>> GetTagsDBEntity()
        {
            return await _context.TagsDBEntity.ToListAsync();
        }

        // GET: api/TagsDBEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tags>> GetTagsDBEntity(Guid id)
        {
            var tagsDBEntity = await _context.TagsDBEntity.FindAsync(id);

            if (tagsDBEntity == null)
            {
                return NotFound();
            }

            return tagsDBEntity;
        }

        // PUT: api/TagsDBEntities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTagsDBEntity(Guid id, Tags tagsDBEntity)
        {
            if (id != tagsDBEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(tagsDBEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagsDBEntityExists(id))
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

        // POST: api/TagsDBEntities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tags>> PostTagsDBEntity(Tags tagsDBEntity)
        {
            _context.TagsDBEntity.Add(tagsDBEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTagsDBEntity", new { id = tagsDBEntity.Id }, tagsDBEntity);
        }

        // DELETE: api/TagsDBEntities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tags>> DeleteTagsDBEntity(Guid id)
        {
            var tagsDBEntity = await _context.TagsDBEntity.FindAsync(id);
            if (tagsDBEntity == null)
            {
                return NotFound();
            }

            _context.TagsDBEntity.Remove(tagsDBEntity);
            await _context.SaveChangesAsync();

            return tagsDBEntity;
        }

        private bool TagsDBEntityExists(Guid id)
        {
            return _context.TagsDBEntity.Any(e => e.Id == id);
        }
    }
}
