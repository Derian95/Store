using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Models;

namespace Store.Controllers
{
    public class CategoriaController : Controller
    {


        private readonly StoreContext _context;

        public CategoriaController()
        {
            _context = new StoreContext();  
        }

        public  async Task<IActionResult> Index(int? id)
        {
            Categorium categoria = new Categorium();

            if(id == null){
                return View(categoria);
            }
            else
            {
                categoria = await _context.Categoria.FindAsync(id);
                return View(categoria);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categorium categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.IdCatgoria == 0)//Creacion del registro nuevo
                {
                    _context.Add(categoria);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _context.Categoria.Update(categoria);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new { id = 0 });
                }
                
            }
            return View(categoria);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorys = await _context.Categoria.ToListAsync();
            return Json(new { data = categorys });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categoria.FindAsync(id);
            if(category == null)
            {
                return Json(new { success = false, message = "Error al borrar " });
            }
            _context.Categoria.Remove(category);
            await _context.SaveChangesAsync();
            return Json(new { success=true,message="Cliente eliminado correctamente" });
        }
    }
}
