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
    public class ProyectosController : ControllerBase
    {
        private readonly DbContextDatos _context;

        public ProyectosController(DbContextDatos context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtener todos los proyectos
        /// </summary>
        /// <returns></returns>
        [HttpGet(Constantes.todos)]
        public async Task<IActionResult> GetProyecto()
        {
            return Ok(await _context.Proyecto.ToListAsync());
        }

        /// <summary>
        /// Obtener un proyecto a partir de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       [HttpGet(Constantes.uno)]
        public async Task<IActionResult> GetProyectos(int id)
        {
            var proyectos = await _context.Proyecto.FindAsync(id);

            if (proyectos == null && id == 1)
            {
                return Ok(new Proyectos());
            }

            return Ok(proyectos);
        }

        /// <summary>
        /// Actualizar un proyecto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="proyectos"></param>
        /// <returns></returns>
        [HttpPut(Constantes.actualizar)]
        public async Task<IActionResult> PutProyectos(int id, Proyectos proyectos)
        {
            if (id != proyectos.idProyecto)
            {
                return BadRequest();
            }

            _context.Entry(proyectos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectosExists(id))
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
        /// Agregar un proyecto
        /// </summary>
        /// <param name="proyectos"></param>
        /// <returns></returns>
        [HttpPost(Constantes.agregar)]
        public async Task<ActionResult<Proyectos>> PostProyectos(Proyectos proyectos)
        {
            _context.Proyecto.Add(proyectos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProyectos", new { id = proyectos.idProyecto }, proyectos);
        }

        /// <summary>
        /// Eliminar un proyecto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Constantes.eliminar)]
        public async Task<ActionResult<Proyectos>> DeleteProyectos(int id)
        {
            var proyectos = await _context.Proyecto.FindAsync(id);
            if (proyectos == null)
            {
                return NotFound();
            }

            _context.Proyecto.Remove(proyectos);
            await _context.SaveChangesAsync();

            return proyectos;
        }

        private bool ProyectosExists(int id)
        {
            return _context.Proyecto.Any(e => e.idProyecto == id);
        }
    }
}
