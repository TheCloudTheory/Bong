using System.IO;
using Bong.Modules.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bong.Modules.Controllers
{
    public class AdminController : Controller
    {
        public AdminController()
        {
            
        }

        public IActionResult Index()
        {
            var coreModules = Directory.EnumerateDirectories(Path.Combine(Directory.GetCurrentDirectory(), "Core"));
            var model = new ModulesViewModel(coreModules);

            return View(model);
        }
    }
}