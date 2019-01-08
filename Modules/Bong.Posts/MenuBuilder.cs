using System.Collections.Generic;
using Bong.Menu;

namespace Bong.Posts
{
    public class MenuBuilder : IAdminMenuBuilder
    {
        public IEnumerable<MenuItem> BuildMenu()
        {
            return new[]
            {
                new MenuItem("Posts", "Posts", "admin/posts", UrlKind.Relative)
            };
        }
    }
}