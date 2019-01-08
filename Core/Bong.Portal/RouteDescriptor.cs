using System.Collections.Generic;
using Bong.Routing;

namespace Bong.Portal
{
    public sealed class RouteDescriptor : IRoutesDescriptor
    {
        public IEnumerable<RouteDescription> GetRoutesDescriptions()
        {
            return new[]
            {
                new RouteDescription("Default", "", new {controller = "Pages", action = "Index"})
            };
        }
    }
}
