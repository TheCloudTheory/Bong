using System.IO;
using System.Reflection;
using Bong.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Bong.Middlewares.ExternalControllers
{
    internal sealed class ExternalControllersMiddleware
    {
        public void Invoke(IMvcBuilder builder)
        {
            foreach (var module in ModulesState.LoadedModules)
            {
                var assemblyPath = Path.Combine(FileSystemHelpers.GetBinariesDirectory(), module.File);
                builder.AddApplicationPart(Assembly.LoadFile(assemblyPath)).AddControllersAsServices();
            }
        }
    }
}