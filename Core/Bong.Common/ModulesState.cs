using System.Collections.Generic;

namespace Bong.Common
{
    internal interface IModulesState
    {
        List<BongModuleDescription> LoadedModules { get; }
    }

    internal sealed class ModulesState : IModulesState
    {
        public ModulesState(IDataDeserializer deserializer)
        {
            LoadedModules = deserializer.Deserialize<List<BongModuleDescription>>("modules");
        }

        public List<BongModuleDescription> LoadedModules { get; }
    }
}