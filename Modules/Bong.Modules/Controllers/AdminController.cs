using System.IO;
using Bong.Common;
using Bong.Modules.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bong.Modules.Controllers
{
    public class AdminController : Controller
    {
        private readonly IModulesState _modulesState;
        private readonly IYamlSerializer _serializer;

        public AdminController(IModulesState modulesState, IYamlSerializer serializer)
        {
            _modulesState = modulesState;
            _serializer = serializer;
        }

        public IActionResult Index()
        {
            var coreModules = Directory.EnumerateDirectories(Path.Combine(Directory.GetCurrentDirectory(), "Core"));
            var modules =
                Directory.EnumerateDirectories(Path.Combine(Directory.GetCurrentDirectory(), "Modules"));
            var model = new ModulesViewModel(coreModules, modules, _modulesState.LoadedModules, _serializer);

            return View(model);
        }
    }
}