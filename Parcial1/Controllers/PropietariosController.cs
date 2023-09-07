using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial1.Models;

namespace Parcial1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropietariosController : ControllerBase
    {
        private readonly Parcial1Context _context;

        public PropietariosController(Parcial1Context context)
        {
            _context = context;
        }

        // GET: api/Propietarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Propietario>>> GetPropietarios()
        {
          if (_context.Propietarios == null)
          {
              return NotFound();
          }
            return await _context.Propietarios.ToListAsync();
        }

        // GET: api/Propietarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Propietario>> GetPropietario(int id)
        {
          if (_context.Propietarios == null)
          {
              return NotFound();
          }
            var propietario = await _context.Propietarios.FindAsync(id);

            if (propietario == null)
            {
                return NotFound();
            }

            return propietario;
        }

        // PUT: api/Propietarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPropietario(int id, Propietario propietario)
        {
            if (id != propietario.Id)
            {
                return BadRequest();
            }

            _context.Entry(propietario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropietarioExists(id))
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

        // POST: api/Propietarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Propietario>> PostPropietario(Propietario propietario)
        {
          if (_context.Propietarios == null)
          {
              return Problem("Entity set 'Parcial1Context.Propietarios'  is null.");
          }
            _context.Propietarios.Add(propietario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PropietarioExists(propietario.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPropietario", new { id = propietario.Id }, propietario);
        }

        // DELETE: api/Propietarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropietario(int id)
        {
            if (_context.Propietarios == null)
            {
                return NotFound();
            }
            var propietario = await _context.Propietarios.FindAsync(id);
            if (propietario == null)
            {
                return NotFound();
            }

            _context.Propietarios.Remove(propietario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropietarioExists(int id)
        {
            return (_context.Propietarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
