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

            return View("List", new ListViewModel(posts));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostViewModel model)
        {
            var post = new PostEntity(model);

            await _provider.Create(post, "posts");

            return await List();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var post = await _provider.Get<PostEntity>("post", id, "posts");
            var model = new PostViewModel(post);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, PostViewModel model)
        {
            var post = await _provider.Get<PostEntity>("post", id, "posts");

            post.Url = model.Url;
            post.Body = model.Body;
            post.Title = model.Title;

            await _provider.Save(post, "posts");

            return await List();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var post = await _provider.Get<PostEntity>("post", id, "posts");

            await _provider.Delete(post, "posts");

            return await List();
        }
    }
}