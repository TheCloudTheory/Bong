using System.Linq;
using System.Threading.Tasks;
using Bong.AzureStorage;
using Bong.Posts.Models;
using Bong.Posts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bong.Posts.Controllers
{
    public class AdminController : Controller
    {
        private readonly ITableStorageProvider _provider;

        public AdminController(ITableStorageProvider provider)
        {
            _provider = provider;
        }

        public async Task<IActionResult> List()
        {
            var posts = (await _provider.List<PostEntity>("posts")).ToArray();

            return View(new ListViewModel(posts));
        }
    }
}