using Microsoft.AspNetCore.Mvc;

namespace Bong.Portal.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}