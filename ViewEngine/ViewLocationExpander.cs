using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Bong.ViewEngine
{
    public class ViewLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context,
            IEnumerable<string> viewLocations)
        {
            if (context.ControllerName.Contains("Admin"))
            {
                var locations = new[]
                {
                    "/Modules/{2}/Views/{1}/{0}" + RazorViewEngine.ViewExtension,
                    "/Themes/Bong.AdminTheme/views/{0}" + RazorViewEngine.ViewExtension,
                    "/Themes/Bong.AdminTheme/views/Shared/{0}" + RazorViewEngine.ViewExtension,
                    "/Themes/Bong.AdminTheme/views/Components/{0}" + RazorViewEngine.ViewExtension
                };

                return locations.Concat(viewLocations);
            }

            return viewLocations;
        }
    }
}