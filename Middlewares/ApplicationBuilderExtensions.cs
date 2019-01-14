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

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var startup = assembly.ExportedTypes.FirstOrDefault(_ => _.Name == "BongStartup");
                if (startup == null)
                {
                    continue;
                }

                InternalLogger.Log($"Executing startup for {assembly.FullName}");
                var instance = Activator.CreateInstance(startup);
                startup.GetMethod("Configure").Invoke(instance, new object[] {app});
            }

            return app;
        }
    }
}