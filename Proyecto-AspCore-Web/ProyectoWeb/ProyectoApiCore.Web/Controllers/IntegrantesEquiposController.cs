using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoApiCore.Web;
using ProyectoApiCore.Web.Contexto;

namespace ProyectoApiCore.Web.Controllers
{
    public class IntegrantesEquiposController : Controller
    {
        private readonly DbContextDatos _context;

        public IntegrantesEquiposController(DbContextDatos context)
        {
            _context = context;
        }

        // GET: IntegrantesEquipos
        public async Task<IActionResult> Index()
        {
            return View(await _context.IntegranteEquipo.ToListAsync());
        }

        // GET: IntegrantesEquipos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var integrantesEquipo = await _context.IntegranteEquipo
                .FirstOrDefaultAsync(m => m.idIntegranteEquipo == id);
            if (integrantesEquipo == null)
            {
                return NotFound();
            }

            return View(integrantesEquipo);
        }

        // GET: IntegrantesEquipos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IntegrantesEquipos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idIntegranteEquipo,idIntegrante,idEquipo")] IntegrantesEquipo integrantesEquipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(integrantesEquipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(integrantesEquipo);
        }

        // GET: IntegrantesEquipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var integrantesEquipo = await _context.IntegranteEquipo.FindAsync(id);
            if (integrantesEquipo == null)
            {
                return NotFound();
            }
            return View(integrantesEquipo);
        }

        // POST: IntegrantesEquipos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idIntegranteEquipo,idIntegrante,idEquipo")] IntegrantesEquipo integrantesEquipo)
        {
            if (id != integrantesEquipo.idIntegranteEquipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(integrantesEquipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntegrantesEquipoExists(integrantesEquipo.idIntegranteEquipo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(integrantesEquipo);
        }

        // GET: IntegrantesEquipos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var integrantesEquipo = await _context.IntegranteEquipo
                .FirstOrDefaultAsync(m => m.idIntegranteEquipo == id);
            if (integrantesEquipo == null)
            {
                return NotFound();
            }

            return View(integrantesEquipo);
        }

        // POST: IntegrantesEquipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var integrantesEquipo = await _context.IntegranteEquipo.FindAsync(id);
            _context.IntegranteEquipo.Remove(integrantesEquipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IntegrantesEquipoExists(int id)
        {
            return _context.IntegranteEquipo.Any(e => e.idIntegranteEquipo == id);
        }
    }
}
