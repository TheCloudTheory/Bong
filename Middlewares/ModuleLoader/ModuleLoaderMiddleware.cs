using System;
using System.IO;
using System.Reflection;
using Bong.Common;
using Bong.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Bong.Middlewares.ModuleLoader
{
    internal sealed class ModuleLoaderMiddleware
    {
        private readonly IModulesState _modulesState;

        public ModuleLoaderMiddleware(IModulesState modulesState)
        {
            _modulesState = modulesState;
            InternalLogger.Log($"Executing {nameof(ModuleLoaderMiddleware)}");
            AppDomain.CurrentDomain.AssemblyResolve += BongResolveEventHandler;
        }

        private static Assembly BongResolveEventHandler(object sender, ResolveEventArgs args)
        {
            var assemblyName = args.Name.Split(",")[0];
            var directory = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var assembly =
                AssemblyLoader.LoadAssemblyIfNotLoaded(Path.Combine(directory.FullName, assemblyName + ".dll"));

            return assembly;
        }

        public void Invoke(IMvcBuilder builder)
        {
            var mainDirectory = Directory.GetCurrentDirectory();

            foreach (var module in _modulesState.LoadedModules)
            {
                var moduleDirectory = module.Type == BongModuleType.Core ? "Core" : "Modules";
                var fullModulePath = Path.Combine(mainDirectory, moduleDirectory, module.Module, "bin");
                var moduleFiles = new DirectoryInfo(fullModulePath);

                InternalLogger.Log($"Copying module {module.Module} to \\bin");
                CopyModuleFilesToBinaries(moduleFiles);
            }
        }

        private void CopyModuleFilesToBinaries(DirectoryInfo moduleFiles)
        {
            foreach (var file in moduleFiles.EnumerateFiles("*.dll", SearchOption.AllDirectories))
            {
                try
                {
                    File.Copy(file.FullName, Path.Combine(FileSystemHelpers.GetBinariesDirectory(), file.Name),
                        false);
                }
                catch (IOException ex)
                {
                    InternalLogger.Log($"Warning: {ex.Message}");
                }
            }
        }
    }
}