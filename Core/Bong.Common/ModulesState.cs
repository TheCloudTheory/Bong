using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Bong.Common
{
    public sealed class ModulesState
    {
        private static readonly List<BongModuleDescription> CurrentlyLoadedModules = new List<BongModuleDescription>();

        internal static bool AreModulesLoaded { get; private set; }

        public static List<BongModuleDescription> LoadedModules
        {
            get
            {
                if (AreModulesLoaded == false)
                {
                    foreach (var module in GetBongModules())
                    {
                        CurrentlyLoadedModules.Add(module);
                    }

                    AreModulesLoaded = true;
                }

                return CurrentlyLoadedModules;
            }
        }

        private static IEnumerable<BongModuleDescription> GetBongModules()
        {
            var mainDirectory = Directory.GetCurrentDirectory();
            var modulesFile = Path.Combine(mainDirectory, "Data", "modules.yaml");
            var fileContent = File.ReadAllText(modulesFile);
            var deserializer = new DeserializerBuilder().WithNamingConvention(new CamelCaseNamingConvention()).Build();
            var modules = deserializer.Deserialize<List<BongModuleDescription>>(fileContent);

            return modules;
        }
    }
}