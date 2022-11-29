using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Store.ViewComponents
{
    public class MenuUsuarioViewComponent:ViewComponent
    {


        public async Task<IViewComponentResult> InvokeAsync()
        {
            ClaimsPrincipal claimsUser = HttpContext.User;
            string nombreUsuario = "";
            string rol = "";

            if (claimsUser.Identity.IsAuthenticated)
            {
                nombreUsuario = claimsUser.Claims
                    .Where(c => c.Type == ClaimTypes.NameIdentifier)
                    .Select(c => c.Value).SingleOrDefault();

                rol = claimsUser.Claims
                    .Where(c => c.Type == ClaimTypes.Role)
                    .Select(c => c.Value).SingleOrDefault();
            }

            ViewData["NombreUsuario"] = nombreUsuario;
            ViewData["Rol"]=rol;

            return View();  
        }
    }
}
