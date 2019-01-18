using System;
using System.Linq;
using Bong.Common;

namespace Bong.Storage
{
    public class StorageStartup
    {
        private readonly IInstallationProvider _installationProvider;

        public StorageStartup(IInstallationProvider installationProvider)
        {
            _installationProvider = installationProvider;
        }

        public IStorage GetStorage()
        {
            InternalLogger.Log("Initializing storage.");

            var storageProviderModuleName = _installationProvider.Installation.StorageProvider;
            var loadedModules = AppDomain.CurrentDomain.GetAssemblies();
            var storageProviderAssembly = loadedModules.First(_ => _.FullName.Contains(storageProviderModuleName));
            var storageProvider =
                storageProviderAssembly.ExportedTypes.First(_ => typeof(IStorage).IsAssignableFrom(_));

            var instance = (IStorage)Activator.CreateInstance(storageProvider);
            return instance;
        }
    }
}