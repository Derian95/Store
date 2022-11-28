using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Models.ViewModel;

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
            ViewModelLogin login = new ViewModelLogin();
            return View();
        }
        [HttpPost]
        public ActionResult Index(ViewModelLogin _login)
        {
            //var user = _context.Usuarios();
            var status = _context.Usuarios.Where(x => x.Correo == _login.correo && x.Clave == _login.clave).FirstOrDefault();

            if (status == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                //ViewBag.LoginStatus = 1;
                //ViewBag.User = status;

                
                 return RedirectToAction("Index", "Usuarios");
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
