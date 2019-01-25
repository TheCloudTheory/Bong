using System.Collections.Generic;

namespace Bong.Modules.ViewModels
{
    public class ModulesViewModel
    {
        public IEnumerable<string> CoreModules { get; }

        public ModulesViewModel(IEnumerable<string> coreModules)
        {
            CoreModules = coreModules;
        }
    }
}