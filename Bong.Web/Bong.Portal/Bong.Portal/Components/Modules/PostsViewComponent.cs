using System.Collections.Generic;
using System.Threading.Tasks;
using Bong.Portal.Core.Storage;
using Bong.Portal.Core.Themes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.Portal.Components.Modules
{
    public class PostsViewComponent : ViewComponent
    {
        private static readonly string TableName = "Posts";

        private readonly StorageProvider _storageProvider;

        public PostsViewComponent()
        {
            _storageProvider = new StorageProvider();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var posts = await _storageProvider.GetAllAsync<PostEntity>(TableName);
            
            return new ThemedComponentView<List<PostEntity>>("_Posts", posts, ViewData);
        }
    }

    public class PostEntity : TableEntity
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Body { get; set; }
        public string Subtitle { get; set; }
    }
}
