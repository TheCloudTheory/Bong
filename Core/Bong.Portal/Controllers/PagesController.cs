using Microsoft.AspNetCore.Mvc;

namespace Bong.Portal.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}