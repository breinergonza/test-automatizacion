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
    public class EquiposController : ControllerBase
    {
        private readonly DbContextDatos _context;

        public EquiposController(DbContextDatos context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtener un listado de todos los equipos parametrizados
        /// </summary>
        /// <returns></returns>
        [HttpGet(Constantes.todos)]
        public async Task<IActionResult> GetEquipo()
        {
            return Ok(await _context.Equipo.ToListAsync());
        }

        /// <summary>
        /// Obtener un equipo a partir de su Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       [HttpGet(Constantes.uno)]
        public async Task<IActionResult> GetEquipos(int id)
        {
            var equipos = await _context.Equipo.FindAsync(id);

            if (equipos == null && id == 1)
            {
                return Ok(new Equipos());
            }

            return Ok(equipos);
        }

        /// <summary>
        /// Actualizar un equipo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="equipos"></param>
        /// <returns></returns>
        [HttpPut(Constantes.actualizar)]
        public async Task<IActionResult> PutEquipos(int id, Equipos equipos)
        {
            if (id != equipos.idEquipo)
            {
                return BadRequest();
            }

            _context.Entry(equipos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquiposExists(id))
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
        /// Agregar un equipo
        /// </summary>
        /// <param name="equipos"></param>
        /// <returns></returns>
        [HttpPost(Constantes.agregar)]
        public async Task<ActionResult<Equipos>> PostEquipos(Equipos equipos)
        {
            _context.Equipo.Add(equipos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipos", new { id = equipos.idEquipo }, equipos);
        }

        /// <summary>
        /// Eliminar un equipo a partir de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Constantes.eliminar)]
        public async Task<ActionResult<Equipos>> DeleteEquipos(int id)
        {
            var equipos = await _context.Equipo.FindAsync(id);
            if (equipos == null)
            {
                return NotFound();
            }

            _context.Equipo.Remove(equipos);
            await _context.SaveChangesAsync();

            return equipos;
        }

        private bool EquiposExists(int id)
        {
            return _context.Equipo.Any(e => e.idEquipo == id);
        }
    }
}
