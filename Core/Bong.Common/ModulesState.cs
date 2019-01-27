using System.Collections.Generic;

namespace Bong.Common
{
    public interface IModulesState
    {
        List<BongModuleDescription> LoadedModules { get; }
    }

    public sealed class ModulesState : IModulesState
    {
        internal ModulesState(IDataDeserializer deserializer)
        {
            LoadedModules = deserializer.Deserialize<List<BongModuleDescription>>("modules");
        }

        public List<BongModuleDescription> LoadedModules { get; }
    }
}