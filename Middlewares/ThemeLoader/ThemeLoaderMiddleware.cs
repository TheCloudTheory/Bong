using System;
using System.IO;
using System.Reflection;
using Bong.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Bong.Middlewares.ThemeLoader
{
    internal sealed class ThemeLoaderMiddleware
    {
        public void Invoke(IMvcBuilder builder)
        {
            try
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var themeAssemblyLocation = Path.Combine(currentDirectory, "Themes", "Bong.Default", "bin", "Debug", "netcoreapp2.1",
                    "Bong.Default.dll");

                var assembly = Assembly.LoadFile(themeAssemblyLocation);

                // Without adding an assembly as an application part,
                // view components won't be discoverable
                builder.AddApplicationPart(assembly);

                File.Copy(themeAssemblyLocation,
                    Path.Combine(FileSystemHelpers.GetBinariesDirectory(), "Bong.Default.dll"),
                    false);

            }
            catch (IOException ex)
            {
                // Ignore...
            }
            catch (Exception ex)
            {

            }
        }
    }
}