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
    public class MovimientosController : ControllerBase
    {
        private readonly DataContext _context;

        public MovimientosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Movimientos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movimientos>>> GetMovimientos()
        {
          if (_context.Movimientos == null)
          {
              return NotFound();
          }
            return await _context.Movimientos.ToListAsync();
        }

        // GET: api/Movimientos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movimientos>> GetMovimientos(int id)
        {
          if (_context.Movimientos == null)
          {
              return NotFound();
          }
            var movimientos = await _context.Movimientos.FindAsync(id);

            if (movimientos == null)
            {
                return NotFound();
            }

            return movimientos;
        }

        // GET: api/Movimientos/Categoria
        [HttpGet("/api/Categoria={idCategoria}-{mes}")]
        public async Task<ActionResult<IEnumerable<Movimientos>>> GetMovimientosCategoria(int? idCategoria, int? mes)
        {
            if(idCategoria == null)
            {
                return NotFound();
            }

             var movimientos = await _context.Movimientos.Where(x => x.IdCategoria == idCategoria && x.Mes == mes).ToListAsync();

            if(movimientos == null)
            {
                return NotFound();
            }

            return movimientos;
           
        }

        

        // PUT: api/Movimientos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovimientos(int id, Movimientos movimientos)
        {
            if (id != movimientos.Id)
            {
                return BadRequest();
            }

            _context.Entry(movimientos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimientosExists(id))
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

        // POST: api/Movimientos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movimientos>> PostMovimientos(Movimientos movimientos)
        {
          if (_context.Movimientos == null)
          {
              return Problem("Entity set 'DataContext.Movimientos'  is null.");
          }
            _context.Movimientos.Add(movimientos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovimientos", new { id = movimientos.Id }, movimientos);
        }

        // DELETE: api/Movimientos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovimientos(int id)
        {
            if (_context.Movimientos == null)
            {
                return NotFound();
            }
            var movimientos = await _context.Movimientos.FindAsync(id);
            if (movimientos == null)
            {
                return NotFound();
            }

            _context.Movimientos.Remove(movimientos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovimientosExists(int id)
        {
            return (_context.Movimientos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
