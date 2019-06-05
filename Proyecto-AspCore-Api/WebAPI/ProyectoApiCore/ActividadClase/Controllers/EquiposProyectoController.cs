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
    public class EquiposProyectoController : ControllerBase
    {
        private readonly DbContextDatos _context;

        public EquiposProyectoController(DbContextDatos context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtener todas las relaciones entre equipos y proyectos
        /// </summary>
        /// <returns></returns>
        [HttpGet(Constantes.todos)]
        public async Task<ActionResult<IEnumerable<EquiposProyecto>>> GetEquipoProyecto()
        {
            return await _context.EquipoProyecto.ToListAsync();
        }

        /// <summary>
        /// Obtener una relación entre un equipo y un proyecto a partir de su Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       [HttpGet(Constantes.uno)]
        public async Task<ActionResult<EquiposProyecto>> GetEquiposProyecto(int id)
        {
            var equiposProyecto = await _context.EquipoProyecto.FindAsync(id);

            if (equiposProyecto == null)
            {
                return NotFound();
            }

            return equiposProyecto;
        }

        /// <summary>
        /// Agregar una relación entre un equipo y un proyecto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="equiposProyecto"></param>
        /// <returns></returns>
        [HttpPut(Constantes.actualizar)]
        public async Task<IActionResult> PutEquiposProyecto(int id, EquiposProyecto equiposProyecto)
        {
            if (id != equiposProyecto.idEquipoProyecto)
            {
                return BadRequest();
            }

            _context.Entry(equiposProyecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquiposProyectoExists(id))
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
        /// Agregar una relación entre un equipo y un proyecto
        /// </summary>
        /// <param name="equiposProyecto"></param>
        /// <returns></returns>
        [HttpPost(Constantes.agregar)]
        public async Task<ActionResult<EquiposProyecto>> PostEquiposProyecto(EquiposProyecto equiposProyecto)
        {
            _context.EquipoProyecto.Add(equiposProyecto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquiposProyecto", new { id = equiposProyecto.idEquipoProyecto }, equiposProyecto);
        }

        /// <summary>
        /// Eliminar una relación entre un equipo y un proyecto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Constantes.eliminar)]
        public async Task<ActionResult<EquiposProyecto>> DeleteEquiposProyecto(int id)
        {
            var equiposProyecto = await _context.EquipoProyecto.FindAsync(id);
            if (equiposProyecto == null)
            {
                return NotFound();
            }

            _context.EquipoProyecto.Remove(equiposProyecto);
            await _context.SaveChangesAsync();

            return equiposProyecto;
        }

        private bool EquiposProyectoExists(int id)
        {
            return _context.EquipoProyecto.Any(e => e.idEquipoProyecto == id);
        }
    }
}
