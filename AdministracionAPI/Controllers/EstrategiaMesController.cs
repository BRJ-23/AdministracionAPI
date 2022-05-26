using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdministracionAPI.Data;
using AdministracionAPI.Modelos;

namespace AdministracionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstrategiaMesController : ControllerBase
    {
        private readonly DataContext _context;

        public EstrategiaMesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/EstrategiaMes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstrategiaMes>>> GetEstrategiaMes()
        {
          if (_context.EstrategiaMes == null)
          {
              return NotFound();
          }
            return await _context.EstrategiaMes.ToListAsync();
        }

        // GET: api/EstrategiaMes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstrategiaMes>> GetEstrategiaMes(int id)
        {
          if (_context.EstrategiaMes == null)
          {
              return NotFound();
          }
            var estrategiaMes = await _context.EstrategiaMes.FindAsync(id);

            if (estrategiaMes == null)
            {
                return NotFound();
            }

            return estrategiaMes;
        }

        // PUT: api/EstrategiaMes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstrategiaMes(int id, EstrategiaMes estrategiaMes)
        {
            if (id != estrategiaMes.ID)
            {
                return BadRequest();
            }

            _context.Entry(estrategiaMes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstrategiaMesExists(id))
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

        // POST: api/EstrategiaMes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EstrategiaMes>> PostEstrategiaMes(EstrategiaMes estrategiaMes)
        {
          if (_context.EstrategiaMes == null)
          {
              return Problem("Entity set 'DataContext.EstrategiaMes'  is null.");
          }
            _context.EstrategiaMes.Add(estrategiaMes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstrategiaMes", new { id = estrategiaMes.ID }, estrategiaMes);
        }

        // DELETE: api/EstrategiaMes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstrategiaMes(int id)
        {
            if (_context.EstrategiaMes == null)
            {
                return NotFound();
            }
            var estrategiaMes = await _context.EstrategiaMes.FindAsync(id);
            if (estrategiaMes == null)
            {
                return NotFound();
            }

            _context.EstrategiaMes.Remove(estrategiaMes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstrategiaMesExists(int id)
        {
            return (_context.EstrategiaMes?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
