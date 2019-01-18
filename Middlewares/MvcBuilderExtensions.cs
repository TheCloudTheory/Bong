using System;
using Bong.Common;
using Bong.Middlewares.ExternalControllers;
using Bong.Middlewares.ModuleLoader;
using Bong.Middlewares.ThemeLoader;
using Microsoft.Extensions.DependencyInjection;

namespace Bong.Middlewares
{
    internal static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddModulesBinariesLoader(this IMvcBuilder builder, IModulesState modulesState)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            var middleware = new ModuleLoaderMiddleware(modulesState);
            middleware.Invoke(builder);

            return builder;
        }

        public static IMvcBuilder AddExternalControllersLoader(this IMvcBuilder builder, IModulesState modulesState)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            var middleware = new ExternalControllersMiddleware(modulesState);
            middleware.Invoke(builder);

            return builder;
        }

        public static IMvcBuilder AddThemeLoader(this IMvcBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            var middleware = new ThemeLoaderMiddleware();
            middleware.Invoke(builder);

            return builder;
        }
    }
}