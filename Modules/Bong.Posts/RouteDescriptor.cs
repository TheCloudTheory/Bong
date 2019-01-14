using System.Collections.Generic;
using Bong.Routing;

namespace Bong.Posts
{
    public class RouteDescriptor : IRoutesDescriptor
    {
        public IEnumerable<RouteDescription> GetRoutesDescriptions()
        {
            return new[]
            {
                new RouteDescription("Bong.Posts.Admin.ListPosts", "admin/posts",
                    new {area ="Bong.Posts", controller = "Admin", action = "List"})
            };
        }
    }
}