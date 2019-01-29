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
                viewLocations = DefineAdminViewLocations(viewLocations);
            }

            if (!string.IsNullOrEmpty(context.AreaName) || !context.ViewName.Contains("Components"))
            {
                return viewLocations;
            }

            var viewAndModule = context.ViewName.Split('|');
            if (viewAndModule.Length < 2)
            {
                return viewLocations;
            }

            var moduleName = viewAndModule[1];
            var viewName = viewAndModule[0].Split('/')[2];
            viewLocations = viewLocations.Concat(new[]
                {"/Modules/" + moduleName + "/Views/{1}/" + viewName + RazorViewEngine.ViewExtension});

            return viewLocations;
        }

        private static IEnumerable<string> DefineAdminViewLocations(IEnumerable<string> viewLocations)
        {
            var locations = new[]
            {
                "/Modules/{2}/Views/{1}/{0}" + RazorViewEngine.ViewExtension,
                "/Themes/Bong.AdminTheme/views/{0}" + RazorViewEngine.ViewExtension,
                "/Themes/Bong.AdminTheme/views/Shared/{0}" + RazorViewEngine.ViewExtension,
                "/Themes/Bong.AdminTheme/views/Components/{0}" + RazorViewEngine.ViewExtension
            };

            viewLocations = locations.Concat(viewLocations);
            return viewLocations;
        }
    }
}