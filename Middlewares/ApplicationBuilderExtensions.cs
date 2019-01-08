using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;

namespace Bong.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseBongStartup(this IApplicationBuilder app)
        {
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

                var instance = Activator.CreateInstance(startup);
                startup.GetMethod("Configure").Invoke(instance, new object[] {app});
            }

            return app;
        }
    }
}