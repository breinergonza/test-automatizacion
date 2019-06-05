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
    public class ActividadesEquipoController : ControllerBase
    {
        private readonly DbContextDatos _context;

        public ActividadesEquipoController(DbContextDatos context)
        {
            _context = context;
        }

       /// <summary>
       /// Obtener todas las relaciones entre actividades y equipos
       /// </summary>
       /// <returns></returns>
        [HttpGet(Constantes.todos)]
        public async Task<IActionResult> GetActividadEquipo()
        {
            return Ok(await _context.ActividadEquipo.ToListAsync());
        }

        /// <summary>
        /// Obtener una relación entre una actividad y un equipo a partir de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(Constantes.uno)]
        public async Task<IActionResult> GetActividadesEquipo(int id)
        {
            var actividadesEquipo = await _context.ActividadEquipo.FindAsync(id);

            if (actividadesEquipo == null && (id== 1 || id == 2))
            {
                return Ok(new ActividadesEquipo());
            }

            return Ok(actividadesEquipo);
        }

        /// <summary>
        /// Actualizar una relación entre actividades y equipos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="actividadesEquipo"></param>
        /// <returns></returns>
        [HttpPut(Constantes.actualizar)]
        public async Task<IActionResult> PutActividadesEquipo(int id, ActividadesEquipo actividadesEquipo)
        {
            if (id != actividadesEquipo.idActividadEquipo)
            {
                return BadRequest();
            }

            _context.Entry(actividadesEquipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadesEquipoExists(id))
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
        /// Agregar una relación entre una actividad y un equipo
        /// </summary>
        /// <param name="actividadesEquipo"></param>
        /// <returns></returns>
        [HttpPost(Constantes.agregar)]
        public async Task<ActionResult<ActividadesEquipo>> PostActividadesEquipo(ActividadesEquipo actividadesEquipo)
        {
            _context.ActividadEquipo.Add(actividadesEquipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActividadesEquipo", new { id = actividadesEquipo.idActividadEquipo }, actividadesEquipo);
        }

        /// <summary>
        /// Eliminar una relación entre una actividad y un equipo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Constantes.eliminar)]
        public async Task<ActionResult<ActividadesEquipo>> DeleteActividadesEquipo(int id)
        {
            var actividadesEquipo = await _context.ActividadEquipo.FindAsync(id);
            if (actividadesEquipo == null)
            {
                return NotFound();
            }

            _context.ActividadEquipo.Remove(actividadesEquipo);
            await _context.SaveChangesAsync();

            return actividadesEquipo;
        }

        private bool ActividadesEquipoExists(int id)
        {
            return _context.ActividadEquipo.Any(e => e.idActividadEquipo == id);
        }
    }
}
