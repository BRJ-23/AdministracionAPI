using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdministracionAPI;
using AdministracionAPI.Data;

namespace AdministracionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstrategiasController : ControllerBase
    {
        private readonly DataContext _context;

        public EstrategiasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Estrategias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estrategias>>> GetEstrategias()
        {
          if (_context.Estrategias == null)
          {
              return NotFound();
          }
            return await _context.Estrategias.ToListAsync();
        }

        // GET: api/Estrategias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estrategias>> GetEstrategias(int id)
        {
          if (_context.Estrategias == null)
          {
              return NotFound();
          }
            var estrategias = await _context.Estrategias.FindAsync(id);

            if (estrategias == null)
            {
                return NotFound();
            }

            return estrategias;
        }

        // PUT: api/Estrategias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstrategias(int id, Estrategias estrategias)
        {
            if (id != estrategias.Id)
            {
                return BadRequest();
            }

            _context.Entry(estrategias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstrategiasExists(id))
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

        // POST: api/Estrategias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estrategias>> PostEstrategias(Estrategias estrategias)
        {
          if (_context.Estrategias == null)
          {
              return Problem("Entity set 'DataContext.Estrategias'  is null.");
          }
            _context.Estrategias.Add(estrategias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstrategias", new { id = estrategias.Id }, estrategias);
        }

        // DELETE: api/Estrategias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstrategias(int id)
        {
            if (_context.Estrategias == null)
            {
                return NotFound();
            }
            var estrategias = await _context.Estrategias.FindAsync(id);
            if (estrategias == null)
            {
                return NotFound();
            }

            _context.Estrategias.Remove(estrategias);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstrategiasExists(int id)
        {
            return (_context.Estrategias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
