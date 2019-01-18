using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bong.Common;
using Bong.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Bong.Routing
{
    public class BongStartup
    {
        public void Configure(IBongContext ctx)
        {
            ctx.Builder.UseMvc(builder => BuildRoutes(builder, ctx.LoadedModules));
        }

        private static void BuildRoutes(IRouteBuilder builder, IEnumerable<BongModuleDescription> loadedModules)
        {
            foreach (var module in loadedModules)
            {
                InternalLogger.Log($"Building routes for module {module.Module}");
                var assemblyPath = Path.Combine(FileSystemHelpers.GetBinariesDirectory(), module.File);
                var assemblyInfo = AssemblyLoader.LoadAssemblyIfNotLoaded(assemblyPath);

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
                InternalLogger.Log($"Mapping route {route.Name}");
                builder.MapRoute(route.Name, route.Template, route.Defaults);
            }
        }
    }
}