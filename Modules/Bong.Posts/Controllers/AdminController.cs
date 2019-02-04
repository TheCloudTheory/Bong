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

        public async Task<IActionResult> ListPosts()
        {
            var posts = (await _provider.List<PostEntity>("posts")).ToArray();

            return View("List", new AdminListViewModel(posts));
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View("Create");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostViewModel model)
        {
            var post = new PostEntity(model);

            await _provider.Create(post, "posts");

            return await ListPosts();
        }

        [HttpGet]
        public async Task<IActionResult> EditPost(string id)
        {
            var post = await _provider.Get<PostEntity>("post", id, "posts");
            var model = new PostViewModel(post);

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(string id, PostViewModel model)
        {
            var post = await _provider.Get<PostEntity>("post", id, "posts");

            post.Url = model.Url;
            post.Body = model.Body;
            post.Title = model.Title;

            await _provider.Save(post, "posts");

            return await ListPosts();
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(string id)
        {
            var post = await _provider.Get<PostEntity>("post", id, "posts");

            await _provider.Delete(post, "posts");

            return await ListPosts();
        }
    }
}