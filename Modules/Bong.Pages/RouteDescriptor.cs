using System.Collections.Generic;
using Bong.Routing;

namespace Bong.Pages
{
    public class RouteDescriptor : IRoutesDescriptor
    {
        public IEnumerable<RouteDescription> GetRoutesDescriptions()
        {
            return new[]
            {
                new RouteDescription("Bong.Pages.Admin.ListPages", "admin/pages",
                    new {area ="Bong.Pages", controller = "Admin", action = "ListPages"}),
                new RouteDescription("Bong.Pages.Admin.CreatePage", "admin/pages/create",
                    new {area ="Bong.Pages", controller = "Admin", action = "CreatePage"}),
                new RouteDescription("Bong.Pages.Admin.EditPage", "admin/pages/edit/{id}",
                    new {area ="Bong.Pages", controller = "Admin", action = "EditPage"}),
                new RouteDescription("Bong.Pages.Admin.DeletePage", "admin/pages/delete/{id}",
                    new {area ="Bong.Pages", controller = "Admin", action = "DeletePage"})
            };
        }
    }
}