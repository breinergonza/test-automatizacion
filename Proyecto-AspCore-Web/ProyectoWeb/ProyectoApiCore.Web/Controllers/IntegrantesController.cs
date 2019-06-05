using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoApiCore.Web.Contexto;

namespace ProyectoApiCore.Web.Controllers
{
    public class IntegrantesController : Controller
    {
        private readonly DbContextDatos _context;

        public IntegrantesController(DbContextDatos context)
        {
            _context = context;
        }

        // GET: Integrantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Integrante.ToListAsync());
        }

        // GET: Integrantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var integrantes = await _context.Integrante
                .FirstOrDefaultAsync(m => m.idIntegrante == id);
            if (integrantes == null)
            {
                return NotFound();
            }

            return View(integrantes);
        }

        // GET: Integrantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Integrantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idIntegrante,numeroDocumento,primerNombre,segundoNombre,primerApellido,segundoApellido,fechaNacimiento,idTipoDocumento")] Integrantes integrantes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(integrantes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(integrantes);
        }

        // GET: Integrantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var integrantes = await _context.Integrante.FindAsync(id);
            if (integrantes == null)
            {
                return NotFound();
            }
            return View(integrantes);
        }

        // POST: Integrantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idIntegrante,numeroDocumento,primerNombre,segundoNombre,primerApellido,segundoApellido,fechaNacimiento,idTipoDocumento")] Integrantes integrantes)
        {
            if (id != integrantes.idIntegrante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(integrantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntegrantesExists(integrantes.idIntegrante))
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
            return View(integrantes);
        }

        // GET: Integrantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var integrantes = await _context.Integrante
                .FirstOrDefaultAsync(m => m.idIntegrante == id);
            if (integrantes == null)
            {
                return NotFound();
            }

            return View(integrantes);
        }

        // POST: Integrantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var integrantes = await _context.Integrante.FindAsync(id);
            _context.Integrante.Remove(integrantes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IntegrantesExists(int id)
        {
            return _context.Integrante.Any(e => e.idIntegrante == id);
        }
    }
}
