using System.Collections.Generic;
using Bong.Routing;

namespace Bong.Security.Basic
{
    public class RouteDescriptor : IRoutesDescriptor
    {
        public IEnumerable<RouteDescription> GetRoutesDescriptions()
        {
            return new[]
            {
                new RouteDescription("Bong.Security.Basic.Login", "login",
                    new {area ="Bong.Security.Basic", controller = "Login", action = "Index"})
            };
        }
    }
}