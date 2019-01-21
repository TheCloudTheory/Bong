using System;
using System.Linq;
using Bong.Common;

namespace Bong.Security
{
    public class SecurityStartup
    {
        private readonly IInstallationProvider _installationProvider;

        public SecurityStartup(IInstallationProvider installationProvider)
        {
            _installationProvider = installationProvider;
        }

        public IAuthenticationProvider GetSecurity()
        {
            InternalLogger.Log("Configuring security.");

            var loadedModules = AppDomain.CurrentDomain.GetAssemblies();
            var securityProviderAssembly = loadedModules.First(_ =>
                _.FullName.Contains(_installationProvider.Installation.SecurityProvider));
            var authenticationProvider =
                securityProviderAssembly.ExportedTypes.First(_ => typeof(IAuthenticationProvider).IsAssignableFrom(_));

            var instance = (IAuthenticationProvider)Activator.CreateInstance(authenticationProvider);
            return instance;
        }
    }
}