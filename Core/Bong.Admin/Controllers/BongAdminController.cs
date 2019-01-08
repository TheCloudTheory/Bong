using Microsoft.AspNetCore.Mvc;

namespace Bong.Admin.Controllers
{
    public class BongAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}