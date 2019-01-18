using System;
using System.Linq;
using Bong.Common;
using Bong.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Bong.Middlewares
{
    internal static class ServiceCollectionExtensions
    {
        public static void AddStorageProvider(this IServiceCollection serviceCollection,
            IInstallationProvider installationProvider)
        {
            var startup = new StorageStartup(installationProvider);
            var storage = startup.GetStorage();

            serviceCollection.AddSingleton(storage);
        }

        public static void RegisterDependencies(this IServiceCollection serviceCollection,
            IModulesState modulesState)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var module in modulesState.LoadedModules)
            {
                InternalLogger.Log($"Registering dependency for module: {module.Module}");

                var assembly = assemblies.First(_ => _.FullName.Contains(module.Module));
                var type = assembly.ExportedTypes.FirstOrDefault(_ => _.Name == "BongServices");
                if (type == null)
                {
                    InternalLogger.Log($"Module {module.Module} does not contain services to register.");
                    continue;
                }

                var instance = Activator.CreateInstance(type);
                type.GetMethod("Register").Invoke(instance, new object[] {serviceCollection});
            }
        }
    }
}