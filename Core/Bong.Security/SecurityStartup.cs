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

        public ISecurityProvider GetSecurity()
        {
            var loadedModules = AppDomain.CurrentDomain.GetAssemblies();
            var securityProviderAssembly = loadedModules.First(_ =>
                _.FullName.Contains(_installationProvider.Installation.SecurityProvider));
            var securityProvider =
                securityProviderAssembly.ExportedTypes.First(_ => typeof(ISecurityProvider).IsAssignableFrom(_));

            var instance = (ISecurityProvider)Activator.CreateInstance(securityProvider);
            return instance;
        }
    }
}