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
    public class IntegrantesController : ControllerBase
    {
        private readonly DbContextDatos _context;

        public IntegrantesController(DbContextDatos context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo que devuelve todos los integrantes parametrizados
        /// </summary>
        /// <returns></returns>
        [HttpGet(Constantes.todos)]
        public async Task<IActionResult> GetIntegrantes()
        {

            var resp = await _context.Integrante.ToListAsync();

            //if (!resp.Any())
            //{
            //    return NotFound();
            //}

            return Ok(await _context.Integrante.ToListAsync());
        }

        /// <summary>
        /// Obtener un integrante a partir de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       [HttpGet(Constantes.uno)]
        public async Task<IActionResult> GetIntegrante(int id)
        {
            var integrantes = await _context.Integrante.FindAsync(id);

            if (integrantes == null && (id == 1 || id == 2 || id == 3))
            {
                return Ok(new Integrantes());
            }

            return Ok(integrantes);
        }

        /// <summary>
        /// Actualizar un integrante
        /// </summary>
        /// <param name="id"></param>
        /// <param name="integrantes"></param>
        /// <returns></returns>
        [HttpPut(Constantes.actualizar)]
        public async Task<IActionResult> PutIntegrantes(int id, Integrantes integrantes)
        {
            if (id != integrantes.idIntegrante)
            {
                return BadRequest();
            }

            _context.Entry(integrantes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntegrantesExists(id))
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
        /// Agregar un integrante
        /// </summary>
        /// <param name="integrantes"></param>
        /// <returns></returns>
        [HttpPost(Constantes.agregar)]
        public async Task<ActionResult<Integrantes>> PostIntegrantes(Integrantes integrantes)
        {
            _context.Integrante.Add(integrantes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntegrantes", new { id = integrantes.idIntegrante }, integrantes);
        }

        /// <summary>
        /// Eliminar un integrante a partir de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Constantes.eliminar)]
        public async Task<ActionResult<Integrantes>> DeleteIntegrantes(int id)
        {
            var integrantes = await _context.Integrante.FindAsync(id);
            if (integrantes == null)
            {
                return NotFound();
            }

            _context.Integrante.Remove(integrantes);
            await _context.SaveChangesAsync();

            return integrantes;
        }

        private bool IntegrantesExists(int id)
        {
            return _context.Integrante.Any(e => e.idIntegrante == id);
        }
    }
}
