using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Bong.Middlewares.ModuleLoader;

namespace Bong.Helpers
{
    public class FileSystemHelpers
    {
        public static IEnumerable<FileInfo> GetSystemBinaries()
        {
            var assemblyDirectory = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var assemblies = assemblyDirectory.EnumerateFiles("*.dll").ToArray();

            return assemblies.ToArray();
        }

        public static IEnumerable<FileInfo> GetSystemBinaries(List<BongModuleDescription> modules)
        {
            var assemblyDirectory = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var assemblies = assemblyDirectory.EnumerateFiles("*.dll").ToArray();

            return assemblies.Where(assembly => modules.FirstOrDefault(_ => _.Module == assembly.Name) != null)
                .ToArray();
        }

        public static string GetBinariesDirectory()
        {
            var mainDirectory = Directory.GetCurrentDirectory();
            return Path.Combine(mainDirectory, "bin", "Debug", "netcoreapp2.1");
        }
    }
}