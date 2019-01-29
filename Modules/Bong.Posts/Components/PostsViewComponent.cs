using System.Linq;
using System.Threading.Tasks;
using Bong.AzureStorage;
using Bong.Posts.Models;
using Bong.Posts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bong.Posts.Components
{
    public class PostsViewComponent : ViewComponent
    {
        private readonly ITableStorageProvider _provider;

        public PostsViewComponent(ITableStorageProvider provider)
        {
            _provider = provider;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = (await _provider.List<PostEntity>("posts")).Select(_ => new PostViewModel(_));
            
            return View("Posts|Bong.Posts", posts);
        }
    }
}