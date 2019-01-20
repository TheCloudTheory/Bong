using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Bong.Common
{
    public class AssemblyLoader
    {
        public static Assembly LoadAssemblyIfNotLoaded(string assemblyLocation)
        {
            var pathParts = assemblyLocation.Split('\\');
            var assemblyName = pathParts[pathParts.Length - 1].Replace(".dll", string.Empty);
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            var loadedAssembly = loadedAssemblies.FirstOrDefault(_ => _.FullName.Contains(assemblyName));
            if (loadedAssembly != null)
            {
                return loadedAssembly;
            }

            if (File.Exists(assemblyLocation) == false)
            {
                InternalLogger.Log($"Could not load {assemblyLocation}");
                return null;
            }

            var assembly = Assembly.LoadFile(assemblyLocation);
            return assembly;
        }
    }
}