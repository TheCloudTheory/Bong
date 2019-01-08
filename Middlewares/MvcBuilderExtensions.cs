using System;
using Bong.Middlewares.ExternalControllers;
using Bong.Middlewares.ModuleLoader;
using Bong.Middlewares.ThemeLoader;
using Microsoft.Extensions.DependencyInjection;

namespace Bong.Middlewares
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddModulesBinariesLoader(this IMvcBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            var middleware = new ModuleLoaderMiddleware();
            middleware.Invoke(builder);

            return builder;
        }

        public static IMvcBuilder AddExternalControllersLoader(this IMvcBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            var middleware = new ExternalControllersMiddleware();
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