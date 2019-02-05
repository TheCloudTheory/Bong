using System.Threading.Tasks;
using Bong.AzureStorage;
using Bong.Posts.Models;
using Bong.Posts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bong.Posts.Controllers
{
    public class ViewController : Controller
    {
        private readonly ITableStorageProvider _provider;

        public ViewController(ITableStorageProvider provider)
        {
            _provider = provider;
        }

        public async Task<IActionResult> ViewPost(string postId)
        {
            var post = await _provider.Get<PostEntity>("post", postId, "posts");
            var model = new PostViewModel(post);

            return View(model);
        }
    }
}