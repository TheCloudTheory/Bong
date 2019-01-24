using System;
using System.Linq;
using Bong.Common;
using Microsoft.Extensions.Configuration;

namespace Bong.Security
{
    public class SecurityStartup
    {
        private readonly IInstallationProvider _installationProvider;
        private readonly IConfigurationRoot _configuration;

        public SecurityStartup(IInstallationProvider installationProvider, IConfigurationRoot configuration)
        {
            _installationProvider = installationProvider;
            _configuration = configuration;
        }

        public IAuthenticationProvider GetSecurity()
        {
            InternalLogger.Log("Configuring security.");

            var loadedModules = AppDomain.CurrentDomain.GetAssemblies();
            var securityProviderAssembly = loadedModules.First(_ =>
                _.FullName.Contains(_installationProvider.Installation.SecurityProvider));
            var authenticationProvider =
                securityProviderAssembly.ExportedTypes.First(_ => typeof(IAuthenticationProvider).IsAssignableFrom(_));

            var ctor = authenticationProvider.GetConstructor(new[] { typeof(IConfigurationRoot)});
            var instance = (IAuthenticationProvider)ctor.Invoke(new object[] {_configuration});

            return instance;
        }
    }
}