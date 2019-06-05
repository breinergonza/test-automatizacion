using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Datos.Contexto;
using Datos.Models;
using IC.Constantes;

namespace ActividadClase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoActividadController : ControllerBase
    {
        private readonly DbContextDatos _context;

        public EstadoActividadController(DbContextDatos context)
        {
            _context = context;
        }

        // GET: api/EstadoActividad
        [HttpGet(Constantes.todos)]
        public async Task<ActionResult<IEnumerable<EstadoActividad>>> GetEstadoActividades()
        {
            return await _context.EstadoActividades.ToListAsync();
        }

        // GET: api/EstadoActividad/5
        [HttpGet(Constantes.uno)]
        public async Task<ActionResult<EstadoActividad>> GetEstadoActividad(int id)
        {
            var estadoActividad = await _context.EstadoActividades.FindAsync(id);

            if (estadoActividad == null)
            {
                return NotFound();
            }

            return estadoActividad;
        }

        // PUT: api/EstadoActividad/5
        [HttpPut(Constantes.actualizar)]
        public async Task<IActionResult> PutEstadoActividad(int id, EstadoActividad estadoActividad)
        {
            if (id != estadoActividad.idEstadoActividad)
            {
                return BadRequest();
            }

            _context.Entry(estadoActividad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoActividadExists(id))
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

        // POST: api/EstadoActividad
        [HttpPost(Constantes.agregar)]
        public async Task<ActionResult<EstadoActividad>> PostEstadoActividad(EstadoActividad estadoActividad)
        {
            _context.EstadoActividades.Add(estadoActividad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstadoActividad", new { id = estadoActividad.idEstadoActividad }, estadoActividad);
        }

        // DELETE: api/EstadoActividad/5
        [HttpDelete(Constantes.eliminar)]
        public async Task<ActionResult<EstadoActividad>> DeleteEstadoActividad(int id)
        {
            var estadoActividad = await _context.EstadoActividades.FindAsync(id);
            if (estadoActividad == null)
            {
                return NotFound();
            }

            _context.EstadoActividades.Remove(estadoActividad);
            await _context.SaveChangesAsync();

            return estadoActividad;
        }

        private bool EstadoActividadExists(int id)
        {
            return _context.EstadoActividades.Any(e => e.idEstadoActividad == id);
        }
    }
}
