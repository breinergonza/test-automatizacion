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
    public class IntegrantesEquipoController : ControllerBase
    {
        private readonly DbContextDatos _context;

        public IntegrantesEquipoController(DbContextDatos context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtener un listado de las relaciones de integrantes y equipos
        /// </summary>
        /// <returns></returns>
        [HttpGet(Constantes.todos)]
        public async Task<ActionResult<IEnumerable<IntegrantesEquipo>>> GetIntegranteEquipo()
        {
            return await _context.IntegranteEquipo.ToListAsync();
        }

        /// <summary>
        /// Obtener una relación entre un integrante y un equipo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       [HttpGet(Constantes.uno)]
        public async Task<ActionResult<IntegrantesEquipo>> GetIntegrantesEquipo(int id)
        {
            var integrantesEquipo = await _context.IntegranteEquipo.FindAsync(id);

            if (integrantesEquipo == null)
            {
                return NotFound();
            }

            return integrantesEquipo;
        }

        /// <summary>
        /// Actualizar una relación entre integrantes y equipos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="integrantesEquipo"></param>
        /// <returns></returns>
        [HttpPut(Constantes.actualizar)]
        public async Task<IActionResult> PutIntegrantesEquipo(int id, IntegrantesEquipo integrantesEquipo)
        {
            if (id != integrantesEquipo.idIntegranteEquipo)
            {
                return BadRequest();
            }

            _context.Entry(integrantesEquipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntegrantesEquipoExists(id))
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

        /// <summary>
        /// Agregar una relación entre un integrante y un equipo
        /// </summary>
        /// <param name="integrantesEquipo"></param>
        /// <returns></returns>
        [HttpPost(Constantes.agregar)]
        public async Task<ActionResult<IntegrantesEquipo>> PostIntegrantesEquipo(IntegrantesEquipo integrantesEquipo)
        {
            _context.IntegranteEquipo.Add(integrantesEquipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntegrantesEquipo", new { id = integrantesEquipo.idIntegranteEquipo }, integrantesEquipo);
        }

        /// <summary>
        /// Eliminar una relación entre integrantes y equipos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Constantes.eliminar)]
        public async Task<ActionResult<IntegrantesEquipo>> DeleteIntegrantesEquipo(int id)
        {
            var integrantesEquipo = await _context.IntegranteEquipo.FindAsync(id);
            if (integrantesEquipo == null)
            {
                return NotFound();
            }

            _context.IntegranteEquipo.Remove(integrantesEquipo);
            await _context.SaveChangesAsync();

            return integrantesEquipo;
        }

        private bool IntegrantesEquipoExists(int id)
        {
            return _context.IntegranteEquipo.Any(e => e.idIntegranteEquipo == id);
        }
    }
}
