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
    public class InversionesController : ControllerBase
    {
        private readonly DataContext _context;

        public InversionesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Inversiones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inversiones>>> GetInversiones()
        {
          if (_context.Inversiones == null)
          {
              return NotFound();
          }
            return await _context.Inversiones.ToListAsync();
        }

        // GET: api/Inversiones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inversiones>> GetInversiones(int id)
        {
          if (_context.Inversiones == null)
          {
              return NotFound();
          }
            var inversiones = await _context.Inversiones.FindAsync(id);

            if (inversiones == null)
            {
                return NotFound();
            }

            return inversiones;
        }

        // PUT: api/Inversiones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInversiones(int id, Inversiones inversiones)
        {
            if (id != inversiones.Id)
            {
                return BadRequest();
            }

            _context.Entry(inversiones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InversionesExists(id))
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

        // POST: api/Inversiones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inversiones>> PostInversiones(Inversiones inversiones)
        {
          if (_context.Inversiones == null)
          {
              return Problem("Entity set 'DataContext.Inversiones'  is null.");
          }
            _context.Inversiones.Add(inversiones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInversiones", new { id = inversiones.Id }, inversiones);
        }

        // DELETE: api/Inversiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInversiones(int id)
        {
            if (_context.Inversiones == null)
            {
                return NotFound();
            }
            var inversiones = await _context.Inversiones.FindAsync(id);
            if (inversiones == null)
            {
                return NotFound();
            }

            _context.Inversiones.Remove(inversiones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InversionesExists(int id)
        {
            return (_context.Inversiones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
