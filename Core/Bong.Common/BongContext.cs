using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;

namespace Bong.Common
{
    public interface IBongContext
    {
        IApplicationBuilder Builder { get; }

        Installation Installation { get; }

        IEnumerable<BongModuleDescription> LoadedModules { get; }
    }

    public sealed class BongContext : IBongContext
    {
        public IApplicationBuilder Builder { get; }
        public Installation Installation { get; }
        public IEnumerable<BongModuleDescription> LoadedModules { get; }

        internal BongContext(IApplicationBuilder builder, Installation installation,
            IEnumerable<BongModuleDescription> loadedModules)
        {
            Builder = builder;
            Installation = installation;
            LoadedModules = loadedModules;
        }
    }
}