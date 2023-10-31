using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult SingIn()
        {
            return View();
        }
    }
}
