using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IC.DTOAdicionales;

namespace ProyectoApiCore.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public IActionResult Index()
        {
            return View();
        }
              
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ingresar([Bind("id, usuario, contrasena")] AccesoUsuario usu)
        {

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }
        
    }
}