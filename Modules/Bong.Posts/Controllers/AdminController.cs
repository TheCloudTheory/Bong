using Microsoft.AspNetCore.Mvc;

namespace Bong.Posts.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}