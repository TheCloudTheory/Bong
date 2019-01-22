using System;
using System.Linq;
using Bong.Common;
using Microsoft.AspNetCore.Builder;

namespace Bong.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseBongStartup(this IApplicationBuilder app)
        {
            InternalLogger.Log("Executing modules startups.");

            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var modulesState = (IModulesState)app.ApplicationServices.GetService(typeof(IModulesState));
            var installationProvider =
                (IInstallationProvider) app.ApplicationServices.GetService(typeof(IInstallationProvider));

            var context = new BongContext(app, installationProvider.Installation,
                modulesState.LoadedModules, app.ApplicationServices);

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (modulesState.LoadedModules.Any(_ => assembly.FullName.Contains(_.Module)) == false)
                {
                    continue;
                }

                InternalLogger.Log($"Searching startup for {assembly.FullName}");

                var startup = assembly.ExportedTypes.FirstOrDefault(_ => _.Name == "BongStartup");
                if (startup == null)
                {
                    continue;
                }

                InternalLogger.Log($"Executing startup for {assembly.FullName}");
                var instance = Activator.CreateInstance(startup);
                startup.GetMethod("Configure").Invoke(instance, new object[] {context});
            }

            return app;
        }
    }
}