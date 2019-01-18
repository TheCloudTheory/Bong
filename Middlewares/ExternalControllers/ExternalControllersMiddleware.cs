using System.IO;
using Bong.Common;
using Bong.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Bong.Middlewares.ExternalControllers
{
    internal sealed class ExternalControllersMiddleware
    {
        private readonly IModulesState _modulesState;

        public ExternalControllersMiddleware(IModulesState modulesState)
        {
            _modulesState = modulesState;
            InternalLogger.Log($"Initializing {nameof(ExternalControllersMiddleware)}");
        }

        public void Invoke(IMvcBuilder builder)
        {
            foreach (var module in _modulesState.LoadedModules)
            {
                InternalLogger.Log($"Adding external controllers from {module.Module} module");
                var assemblyPath = Path.Combine(FileSystemHelpers.GetBinariesDirectory(), module.File);
                builder.AddApplicationPart(AssemblyLoader.LoadAssemblyIfNotLoaded(assemblyPath))
                    .AddControllersAsServices();
            }
        }
    }
}