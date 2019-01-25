using System.Collections.Generic;
using Bong.Routing;

namespace Bong.Modules
{
    public class RouteDescriptor : IRoutesDescriptor
    {
        public IEnumerable<RouteDescription> GetRoutesDescriptions()
        {
            return new[]
            {
                new RouteDescription("Bong.Modules.Admin.ListModules", "admin/modules",
                    new {area ="Bong.Modules", controller = "Admin", action = "Index"}),
            };
        }
    }
}