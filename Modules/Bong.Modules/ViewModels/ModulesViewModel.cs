using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bong.Common;

namespace Bong.Modules.ViewModels
{
    public class ModulesViewModel
    {
        public List<ModuleViewModel> CoreModules { get; }
        public List<ModuleViewModel> Modules{ get; }

        public ModulesViewModel(IEnumerable<string> coreModules, IEnumerable<string> modules,
            IReadOnlyCollection<BongModuleDescription> modulesState)
        {
            CoreModules = ExtractModulesMetadata(coreModules, modulesState);
            Modules = ExtractModulesMetadata(modules, modulesState);
        }

        private List<ModuleViewModel> ExtractModulesMetadata(IEnumerable<string> modules, IEnumerable<BongModuleDescription> state)
        {
            var bongModuleDescriptions = state as BongModuleDescription[] ?? state.ToArray();

            return (from module in modules
                select module.Split("\\")
                into pathParts
                select pathParts[pathParts.Length - 1]
                into moduleName
                select bongModuleDescriptions.Any(_ => _.Module == moduleName)
                    ? new ModuleViewModel(moduleName, true)
                    : new ModuleViewModel(moduleName, false)).ToList();
        }
    }

    public class ModuleViewModel
    {
        public string ModuleName { get; }
        public bool IsEnabled { get; }

        public ModuleViewModel(string moduleName, bool isEnabled)
        {
            ModuleName = moduleName;
            IsEnabled = isEnabled;
        }
    }
}