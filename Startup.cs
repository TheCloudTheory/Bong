using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Bong.Helpers;
using Bong.Middlewares;
using Bong.Routing;
using Bong.ViewEngine;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Bong
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddModulesBinariesLoader()
                .AddExternalControllersLoader()
                .AddThemeLoader();

            ViewEngineSetter.ConfigureBongEcosystem(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
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
