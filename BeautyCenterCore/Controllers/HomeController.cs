using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeautyCenterCore.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BeautyCenterCore.Controllers
{
    public class HomeController : Controller
    {
        private BeautyCoreDb _context;
        public HomeController(BeautyCoreDb context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Usuarios.ToList());
        }

        public IActionResult Error()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuarios user)
        {
            var account = _context.Usuarios.Where(u => u.NombreUsuario == user.NombreUsuario && u.Contraseña == user.Contraseña).FirstOrDefault();
            if (account != null)
            {
                HttpContext.Session.SetString("UsuarioId", account.UsuarioId.ToString());
                HttpContext.Session.SetString("NombreUsuario", account.NombreUsuario);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account.NombreUsuario)
                };

                var Identity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(Identity);

                HttpContext.Authentication.SignInAsync("CookiePolicy", principal);

                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "El usuario o contraseña incorrecto!!!.");
            }
            return View();
        }
        
        public ActionResult Logout()
        {
            HttpContext.Authentication.SignOutAsync("CookiePolicy");
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
