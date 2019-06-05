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
    public class ActividadesController : ControllerBase
    {
        private readonly DbContextDatos _context;

        public ActividadesController(DbContextDatos context)
        {
            _context = context;
        }

        // GET: api/Actividades
        [HttpGet(Constantes.todos)]
        public async Task<ActionResult<IEnumerable<Actividades>>> GetActividad()
        {
            return await _context.Actividad.ToListAsync();
        }

        // GET: api/Actividades/5
        [HttpGet(Constantes.uno)]
        public async Task<ActionResult<Actividades>> GetActividades(int id)
        {
            var actividades = await _context.Actividad.FindAsync(id);

            if (actividades == null)
            {
                return NotFound();
            }

            return actividades;
        }

        // PUT: api/Actividades/5
        [HttpPut(Constantes.actualizar)]
        public async Task<IActionResult> PutActividades(int id, Actividades actividades)
        {
            if (id != actividades.idActividad)
            {
                return BadRequest();
            }

            _context.Entry(actividades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadesExists(id))
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

        // POST: api/Actividades
        [HttpPost(Constantes.agregar)]
        public async Task<ActionResult<Actividades>> PostActividades(Actividades actividades)
        {
            _context.Actividad.Add(actividades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActividades", new { id = actividades.idActividad }, actividades);
        }

        // DELETE: api/Actividades/5
        [HttpDelete(Constantes.eliminar)]
        public async Task<ActionResult<Actividades>> DeleteActividades(int id)
        {
            var actividades = await _context.Actividad.FindAsync(id);
            if (actividades == null)
            {
                return NotFound();
            }

            _context.Actividad.Remove(actividades);
            await _context.SaveChangesAsync();

            return actividades;
        }

        private bool ActividadesExists(int id)
        {
            return _context.Actividad.Any(e => e.idActividad == id);
        }
    }
}
