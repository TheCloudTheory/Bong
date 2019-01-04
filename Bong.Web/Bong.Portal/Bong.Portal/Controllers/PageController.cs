using Bong.Portal.Core.Themes;
using Microsoft.AspNetCore.Mvc;

namespace Bong.Portal.Controllers
{
    public class PageController : Controller
    {
        public PageController()
        {
            
        }

        public IActionResult Index()
        {
            return new ThemedView("Index");
        }
    }
}