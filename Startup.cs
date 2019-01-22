using System;
using System.Linq;
using Bong.Common;
using Bong.Middlewares;
using Bong.ViewEngine;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bong
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                InternalLogger.Log("Configuring services.");

                var deserializer = new DataDeserializer();
                var modulesState = new ModulesState(deserializer);
                var installationProvider = new InstallationProvider(deserializer);

                services.AddSingleton<IDataDeserializer>(deserializer);
                services.AddSingleton<IModulesState>(modulesState);
                services.AddSingleton<IInstallationProvider>(installationProvider);
                services.AddSingleton(Configuration);

                services
                    .AddMvc()
                    .AddModulesBinariesLoader(modulesState)
                    .AddExternalControllersLoader(modulesState)
                    .AddThemeLoader();

                services.Configure<MvcOptions>(configure => ConfigureFilters(configure, modulesState));

                services.AddStorageProvider(installationProvider);
                services.AddSecurityProvider(installationProvider);
                services.RegisterDependencies(modulesState);

                ViewEngineSetter.ConfigureBongEcosystem(services);
            }
            catch (Exception ex)
            {
                InternalLogger.Log($"{ex.Message}\r\n{ex.StackTrace}");
                throw;
            }
            
        }

        private static void ConfigureFilters(MvcOptions configure, IModulesState modulesState)
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var module in modulesState.LoadedModules)
            {
                var assembly = loadedAssemblies.First(_ => _.FullName.Contains(module.Module));
                var filters = assembly.ExportedTypes.Where(_ =>
                    typeof(IFilterMetadata).IsAssignableFrom(_) && _.Name.Contains("Controller") == false).ToArray();
                if (filters.Any() == false)
                {
                    InternalLogger.Log($"Module {module.Module} does not contain filters defined.");
                    continue;
                }

                foreach (var filter in filters)
                {
                    configure.Filters.Add(filter);
                    InternalLogger.Log($"Filter {filter.Name} added for module {module.Module}");
                }
            }
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
