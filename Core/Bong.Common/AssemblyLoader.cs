using System;
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

            var assembly = Assembly.LoadFile(assemblyLocation);
            return assembly;
        }
    }
}