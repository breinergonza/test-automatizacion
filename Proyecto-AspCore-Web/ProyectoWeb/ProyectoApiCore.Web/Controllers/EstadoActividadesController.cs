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
    public class EstadoActividadesController : Controller
    {
        private readonly DbContextDatos _context;

        public EstadoActividadesController(DbContextDatos context)
        {
            _context = context;
        }

        // GET: EstadoActividades
        public async Task<IActionResult> Index()
        {
            return View(await _context.EstadoActividades.ToListAsync());
        }

        // GET: EstadoActividades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoActividad = await _context.EstadoActividades
                .FirstOrDefaultAsync(m => m.idEstadoActividad == id);
            if (estadoActividad == null)
            {
                return NotFound();
            }

            return View(estadoActividad);
        }

        // GET: EstadoActividades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoActividades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idEstadoActividad,nombreEstado")] EstadoActividad estadoActividad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoActividad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoActividad);
        }

        // GET: EstadoActividades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoActividad = await _context.EstadoActividades.FindAsync(id);
            if (estadoActividad == null)
            {
                return NotFound();
            }
            return View(estadoActividad);
        }

        // POST: EstadoActividades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idEstadoActividad,nombreEstado")] EstadoActividad estadoActividad)
        {
            if (id != estadoActividad.idEstadoActividad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoActividad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoActividadExists(estadoActividad.idEstadoActividad))
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
            return View(estadoActividad);
        }

        // GET: EstadoActividades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoActividad = await _context.EstadoActividades
                .FirstOrDefaultAsync(m => m.idEstadoActividad == id);
            if (estadoActividad == null)
            {
                return NotFound();
            }

            return View(estadoActividad);
        }

        // POST: EstadoActividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoActividad = await _context.EstadoActividades.FindAsync(id);
            _context.EstadoActividades.Remove(estadoActividad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoActividadExists(int id)
        {
            return _context.EstadoActividades.Any(e => e.idEstadoActividad == id);
        }
    }
}
