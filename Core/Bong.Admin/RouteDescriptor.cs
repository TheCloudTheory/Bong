using System.Collections.Generic;
using Bong.Routing;

namespace Bong.Admin
{
    public class RouteDescriptor : IRoutesDescriptor
    {
        public IEnumerable<RouteDescription> GetRoutesDescriptions()
        {
            return new[]
            {
                new RouteDescription("Admin.Index", "admin", new {controller = "BongAdmin", action = "Index"})
            };
        }
    }
}