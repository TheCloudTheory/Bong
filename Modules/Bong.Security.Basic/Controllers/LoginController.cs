using Microsoft.AspNetCore.Mvc;

namespace Bong.Security.Basic.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}