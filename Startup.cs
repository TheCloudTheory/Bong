using Bong.Common;
using Bong.Middlewares;
using Bong.ViewEngine;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Bong
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            InternalLogger.Log("Configuring services.");

            var deserializer = new DataDeserializer();
            var modulesState = new ModulesState(deserializer);

            services.AddSingleton<IDataDeserializer>(deserializer);
            services.AddSingleton<IModulesState>(modulesState);

            services
                .AddMvc()
                .AddModulesBinariesLoader(modulesState)
                .AddExternalControllersLoader(modulesState)
                .AddThemeLoader();

            ViewEngineSetter.ConfigureBongEcosystem(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InternalLogger.Log("Configuring application.");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseBongStartup();
        }
    }
}
