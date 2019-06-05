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
    public class ActividadesEquiposController : Controller
    {
        private readonly DbContextDatos _context;

        public ActividadesEquiposController(DbContextDatos context)
        {
            _context = context;
        }

        // GET: ActividadesEquipos
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActividadEquipo.ToListAsync());
        }

        // GET: ActividadesEquipos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividadesEquipo = await _context.ActividadEquipo
                .FirstOrDefaultAsync(m => m.idActividadEquipo == id);
            if (actividadesEquipo == null)
            {
                return NotFound();
            }

            return View(actividadesEquipo);
        }

        // GET: ActividadesEquipos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActividadesEquipos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idActividadEquipo,idEquipo,idActividad")] ActividadesEquipo actividadesEquipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actividadesEquipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actividadesEquipo);
        }

        // GET: ActividadesEquipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividadesEquipo = await _context.ActividadEquipo.FindAsync(id);
            if (actividadesEquipo == null)
            {
                return NotFound();
            }
            return View(actividadesEquipo);
        }

        // POST: ActividadesEquipos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idActividadEquipo,idEquipo,idActividad")] ActividadesEquipo actividadesEquipo)
        {
            if (id != actividadesEquipo.idActividadEquipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actividadesEquipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActividadesEquipoExists(actividadesEquipo.idActividadEquipo))
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
            return View(actividadesEquipo);
        }

        // GET: ActividadesEquipos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividadesEquipo = await _context.ActividadEquipo
                .FirstOrDefaultAsync(m => m.idActividadEquipo == id);
            if (actividadesEquipo == null)
            {
                return NotFound();
            }

            return View(actividadesEquipo);
        }

        // POST: ActividadesEquipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actividadesEquipo = await _context.ActividadEquipo.FindAsync(id);
            _context.ActividadEquipo.Remove(actividadesEquipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActividadesEquipoExists(int id)
        {
            return _context.ActividadEquipo.Any(e => e.idActividadEquipo == id);
        }
    }
}
