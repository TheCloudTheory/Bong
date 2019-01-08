using System.Collections.Generic;
using Bong.Routing;

namespace Bong.Admin
{
    public class RouteDescriptor : IRoutesDescriptor
    {
        public IEnumerable<RouteDescription> GetRoutesDescriptions()
        {
            return new RouteDescription[0];
        }
    }
}