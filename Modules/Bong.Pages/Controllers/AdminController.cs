using System.Linq;
using System.Threading.Tasks;
using Bong.AzureStorage;
using Bong.Pages.Models;
using Bong.Pages.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bong.Pages.Controllers
{
    public class AdminController : Controller
    {
        private readonly ITableStorageProvider _provider;

        public AdminController(ITableStorageProvider provider)
        {
            _provider = provider;
        }

        public async Task<IActionResult> ListPages()
        {
            var posts = (await _provider.List<PageEntity>("pages")).ToArray();

            return View("List");
        }

        [HttpGet]
        public IActionResult CreatePage()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePage(PageViewModel model)
        {
            var post = new PageEntity(model);

            await _provider.Create(post, "pages");

            return await ListPages();
        }

        [HttpGet]
        public async Task<IActionResult> EditPage(string id)
        {
            var post = await _provider.Get<PageEntity>("page", id, "pages");
            var model = new PageViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPage(string id, PageViewModel model)
        {
            var post = await _provider.Get<PageEntity>("page", id, "pages");

            post.Url = model.Url;
            post.Body = model.Body;
            post.Title = model.Title;

            await _provider.Save(post, "pages");

            return await ListPages();
        }

        [HttpPost]
        public async Task<IActionResult> DeletePage(string id)
        {
            var post = await _provider.Get<PageEntity>("page", id, "pages");

            await _provider.Delete(post, "pages");

            return await ListPages();
        }
    }
}