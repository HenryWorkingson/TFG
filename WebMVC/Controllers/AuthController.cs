using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Web;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebMVC.DTOS;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;

namespace WebMVC.Controllers
{
    public class AuthController : Controller
    {
        protected AplicationDbContext db;
        public AuthController(AplicationDbContext _db)
        {
            db = _db;
        }

        [HttpGet]
        [Route("Restaurante/LogIn")]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [Route("Restaurante/LogIn")]
        public IActionResult LogIn([FromBody] DTOUser u)
        {
            if (IsValid(u.Correo_Cuenta,u.Password_Cuenta))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,u.Correo_Cuenta)
                };
                var claimsIdentity = new ClaimsIdentity(claims,"Login");
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                    new ClaimsPrincipal(claimsIdentity) );

                return Ok(Redirect("/Admin/Index/"));

            }
            else
                return RedirectToAction("LogIn");
        }

        private bool IsValid(string correo, string password)
        {
            bool b = false;
            if (ModelState.IsValid)
            {
                var u = db.Cuentas;
                foreach (var q in u)
                {
                    if (q.Correo_Cuenta.Equals(correo))
                        if (q.Password_Cuenta.Equals(password))
                        {
                            b = true;
                            break;
                        }
                }
            }
            return b;
        }

        [HttpPost]
        [Route("Admin/LogOut")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("LogIn");
        }
    }
}
