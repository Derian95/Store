using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Models;
using Store.Models.ViewModel;
using System.Security.Claims;

namespace Store.Controllers
{
    public class LoginController : Controller
    {

        private readonly StoreContext _context;

        public LoginController(StoreContext context)
        {
            _context = context;
        }



        // GET: LoginController
        public ActionResult Index()
        {
            //ViewModelLogin login = new();

            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(ViewModelLogin _login)
        {
            Rol rol = new();
            var status = _context.Usuarios.Where(x => x.Correo == _login.correo && x.Clave == _login.clave).FirstOrDefault();

            rol = _context.Rols.Where(x => x.IdRol == status.IdRol).FirstOrDefault();
            
            if (status == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                //ViewBag.LoginStatus = 1;
                //ViewBag.User = status;
                List<Claim> claims = new()
                {
                    new Claim(ClaimTypes.Name,status.Nombre),
                    new Claim(ClaimTypes.NameIdentifier,status.Nombre.ToString()),
                    new Claim(ClaimTypes.Role,rol.Nombre.ToString()),
                    //new Claim("UrlFoto",usuerio.Foto);
                };


                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
                    properties);

                return RedirectToAction("Index", "Home");
            }

            return View(_login);
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
