using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoApiCore.Web.Contexto;

namespace ProyectoApiCore.Web.Controllers
{
    public class ActividadesController : Controller
    {
        private readonly DbContextDatos _context;

        public ActividadesController(DbContextDatos context)
        {
            _context = context;
        }

        // GET: Actividades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Actividad.ToListAsync());
        }

        // GET: Actividades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividades = await _context.Actividad
                .FirstOrDefaultAsync(m => m.idActividad == id);
            if (actividades == null)
            {
                return NotFound();
            }

            return View(actividades);
        }

        // GET: Actividades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actividades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idActividad,nombreActividad,descripcionActividad,fechaInicio,fechaFin")] Actividades actividades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actividades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actividades);
        }

        // GET: Actividades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividades = await _context.Actividad.FindAsync(id);
            if (actividades == null)
            {
                return NotFound();
            }
            return View(actividades);
        }

        // POST: Actividades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idActividad,nombreActividad,descripcionActividad,fechaInicio,fechaFin")] Actividades actividades)
        {
            if (id != actividades.idActividad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actividades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActividadesExists(actividades.idActividad))
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
            return View(actividades);
        }

        // GET: Actividades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividades = await _context.Actividad
                .FirstOrDefaultAsync(m => m.idActividad == id);
            if (actividades == null)
            {
                return NotFound();
            }

            return View(actividades);
        }

        // POST: Actividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actividades = await _context.Actividad.FindAsync(id);
            _context.Actividad.Remove(actividades);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActividadesExists(int id)
        {
            return _context.Actividad.Any(e => e.idActividad == id);
        }
    }
}
