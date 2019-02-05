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
                    new {area ="Bong.Posts", controller = "Admin", action = "ListPosts"}),
                new RouteDescription("Bong.Posts.Admin.CreatePost", "admin/posts/create",
                    new {area ="Bong.Posts", controller = "Admin", action = "CreatePost"}),
                new RouteDescription("Bong.Posts.Admin.EditPost", "admin/posts/edit/{id}",
                    new {area ="Bong.Posts", controller = "Admin", action = "EditPost"}),
                new RouteDescription("Bong.Posts.Admin.DeletePost", "admin/posts/delete/{id}",
                    new {area ="Bong.Posts", controller = "Admin", action = "DeletePost"}),
                new RouteDescription("Bong.Posts.View", "blog/{postId}",
                    new {area ="Bong.Posts", controller = "View", action = "ViewPost"})
            };
        }
    }
}