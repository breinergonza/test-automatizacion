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
    public class TiposDocumentoController : ControllerBase
    {
        private readonly DbContextDatos _context;

        public TiposDocumentoController(DbContextDatos context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtener los tipos de documento
        /// </summary>
        /// <returns></returns>
        [HttpGet(Constantes.todos)]
        public async Task<ActionResult<IEnumerable<TiposDocumento>>> GetTipoDocumento()
        {
            return await _context.TipoDocumento.ToListAsync();
        }

        /// <summary>
        /// Obtener un tipo de documento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       [HttpGet(Constantes.uno)]
        public async Task<ActionResult<TiposDocumento>> GetTiposDocumento(int id)
        {
            var tiposDocumento = await _context.TipoDocumento.FindAsync(id);

            if (tiposDocumento == null)
            {
                return NotFound();
            }

            return tiposDocumento;
        }

        /// <summary>
        /// Actualizar un tipo de documento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tiposDocumento"></param>
        /// <returns></returns>
        [HttpPut(Constantes.actualizar)]
        public async Task<IActionResult> PutTiposDocumento(int id, TiposDocumento tiposDocumento)
        {
            if (id != tiposDocumento.idTipoDocumento)
            {
                return BadRequest();
            }

            _context.Entry(tiposDocumento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposDocumentoExists(id))
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
        /// Agregar un tipo de documento
        /// </summary>
        /// <param name="tiposDocumento"></param>
        /// <returns></returns>
        [HttpPost(Constantes.agregar)]
        public async Task<ActionResult<TiposDocumento>> PostTiposDocumento(TiposDocumento tiposDocumento)
        {
            _context.TipoDocumento.Add(tiposDocumento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiposDocumento", new { id = tiposDocumento.idTipoDocumento }, tiposDocumento);
        }

        /// <summary>
        /// Eliminar un tipo e documento a partir de su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Constantes.eliminar)]
        public async Task<ActionResult<TiposDocumento>> DeleteTiposDocumento(int id)
        {
            var tiposDocumento = await _context.TipoDocumento.FindAsync(id);
            if (tiposDocumento == null)
            {
                return NotFound();
            }

            _context.TipoDocumento.Remove(tiposDocumento);
            await _context.SaveChangesAsync();

            return tiposDocumento;
        }

        private bool TiposDocumentoExists(int id)
        {
            return _context.TipoDocumento.Any(e => e.idTipoDocumento == id);
        }
    }
}
