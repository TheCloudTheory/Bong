using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bong.Common;

namespace Bong.Modules.ViewModels
{
    public class ModulesViewModel
    {
        private IYamlSerializer _serializer;

        public List<ModuleViewModel> CoreModules { get; }
        public List<ModuleViewModel> Modules{ get; }

        public ModulesViewModel(IEnumerable<string> coreModules, IEnumerable<string> modules,
            IReadOnlyCollection<BongModuleDescription> modulesState, IYamlSerializer serializer)
        {
            _serializer = serializer;

            CoreModules = ExtractModulesMetadata(coreModules, modulesState);
            Modules = ExtractModulesMetadata(modules, modulesState);
        }

        private List<ModuleViewModel> ExtractModulesMetadata(IEnumerable<string> modules, IEnumerable<BongModuleDescription> state)
        {
            var result = new List<ModuleViewModel>();
            var bongModuleDescriptions = state as BongModuleDescription[] ?? state.ToArray();

            foreach (var module in modules)
            {
                var moduleDescriptionPath = Path.Combine(module, "module.yaml");
                var moduleDescription =
                    _serializer.Deserialize<ModuleDescription>(File.ReadAllText(moduleDescriptionPath));

                var pathParts = module.Split("\\");
                var moduleName = pathParts[pathParts.Length - 1];

                if (bongModuleDescriptions.Any(_ => _.Module == moduleName))
                {
                    result.Add(new ModuleViewModel(moduleDescription, true));
                }
                else
                {
                    result.Add(new ModuleViewModel(moduleDescription, false));
                }
            }

            return result;
        }
    }

    public class ModuleViewModel
    {
        public ModuleDescription Module { get; }
        public bool IsEnabled { get; }

        public ModuleViewModel(ModuleDescription module, bool isEnabled)
        {
            Module = module;
            IsEnabled = isEnabled;
        }
    }
}