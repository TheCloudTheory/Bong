using System;
using System.Linq;
using Bong.Common;
using Microsoft.Extensions.Configuration;

namespace Bong.Storage
{
    public class StorageStartup
    {
        private readonly IInstallationProvider _installationProvider;
        private readonly IConfigurationRoot _configuration;

        public StorageStartup(IInstallationProvider installationProvider, IConfigurationRoot configuration)
        {
            _installationProvider = installationProvider;
            _configuration = configuration;
        }

        public IStorage GetStorage()
        {
            InternalLogger.Log("Initializing storage.");

            var storageProviderModuleName = _installationProvider.Installation.StorageProvider;
            var loadedModules = AppDomain.CurrentDomain.GetAssemblies();
            var storageProviderAssembly = loadedModules.First(_ => _.FullName.Contains(storageProviderModuleName));
            var storageProvider =
                storageProviderAssembly.ExportedTypes.First(_ => typeof(IStorage).IsAssignableFrom(_));

            var ctor = storageProvider.GetConstructor(new[] { typeof(IConfigurationRoot)});
            var instance = (IStorage)ctor.Invoke(new object[] {_configuration});

            instance.Initialize();

            return instance;
        }
    }
}