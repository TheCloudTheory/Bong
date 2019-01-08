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
                LoadTheme(builder, "Bong.Default");
                LoadTheme(builder, "Bong.AdminTheme");
            }
            catch (IOException ex)
            {
                // Ignore...
            }
            catch (Exception ex)
            {
            }
        }

        private static void LoadTheme(IMvcBuilder builder, string themeName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var themeAssemblyLocation = Path.Combine(currentDirectory, "Themes", themeName, "bin", "Debug",
                "netcoreapp2.1",
                $"{themeName}.dll");

            var assembly = Assembly.LoadFile(themeAssemblyLocation);

            // Without adding an assembly as an application part,
            // view components won't be discoverable
            builder.AddApplicationPart(assembly);

            File.Copy(themeAssemblyLocation,
                Path.Combine(FileSystemHelpers.GetBinariesDirectory(), $"{themeName}.dll"),
                false);
        }
    }
}