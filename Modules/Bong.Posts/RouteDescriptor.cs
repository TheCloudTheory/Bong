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
                    new {area ="Bong.Posts", controller = "Admin", action = "List"}),
                new RouteDescription("Bong.Posts.Admin.CreatePost", "admin/posts/create",
                    new {area ="Bong.Posts", controller = "Admin", action = "Create"}),
                new RouteDescription("Bong.Posts.Admin.EditPost", "admin/posts/edit/{id}",
                    new {area ="Bong.Posts", controller = "Admin", action = "Edit"}),
                new RouteDescription("Bong.Posts.Admin.DeletePost", "admin/posts/delete/{id}",
                    new {area ="Bong.Posts", controller = "Admin", action = "Delete"})
            };
        }
    }
}