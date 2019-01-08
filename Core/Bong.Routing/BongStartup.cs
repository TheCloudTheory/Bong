using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Bong.Common;
using Bong.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Bong.Routing
{
    public class BongStartup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc(BuildRoutes);
        }

        private static void BuildRoutes(IRouteBuilder builder)
        {
            foreach (var module in ModulesState.LoadedModules)
            {
                var assemblyPath = Path.Combine(FileSystemHelpers.GetBinariesDirectory(), module.File);
                var assemblyInfo = Assembly.LoadFrom(assemblyPath);

                var assemblyRouteDescriptorType =
                    assemblyInfo.ExportedTypes.FirstOrDefault(_ =>
                        _.IsInterface == false && typeof(IRoutesDescriptor).IsAssignableFrom(_));
                if (assemblyRouteDescriptorType == null)
                {
                    continue;
                }

                var descriptor = (IRoutesDescriptor) Activator.CreateInstance(assemblyRouteDescriptorType);
                MapRoutesFromDescriptor(builder, descriptor);
            }
        }

        private static void MapRoutesFromDescriptor(IRouteBuilder builder, IRoutesDescriptor assemblyRoutesDescriptor)
        {
            foreach (var route in assemblyRoutesDescriptor.GetRoutesDescriptions())
            {
                builder.MapRoute(route.Name, route.Template, route.Defaults);
            }
        }
    }
}