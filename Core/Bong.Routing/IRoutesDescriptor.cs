using System.Collections.Generic;

namespace Bong.Routing
{
    public interface IRoutesDescriptor
    {
        IEnumerable<RouteDescription> GetRoutesDescriptions();
    }
}