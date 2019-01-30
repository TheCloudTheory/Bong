using System;
using System.Linq;
using System.Reflection;
using Bong.Common;

namespace Bong.Menu
{
    public class BongStartup
    {
        public void Configure(IBongContext ctx)
        {
            var cache = (IMenuCache)ctx.ServiceProvider.GetService(typeof(IMenuCache));

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (ctx.LoadedModules.All(_ => _.Module != assembly.GetName().Name))
                {
                    continue;
                }

                BuildAdminMenu(assembly, cache);
                BuildMenu(assembly, cache);
            }
        }

        private static void BuildAdminMenu(Assembly assembly, IMenuCache cache)
        {
            var adminMenuBuilder =
                assembly.ExportedTypes.FirstOrDefault(_ =>
                    _.IsInterface == false && typeof(IAdminMenuBuilder).IsAssignableFrom(_));
            if (adminMenuBuilder == null)
            {
                return;
            }

            InternalLogger.Log($"Building admin menu for module {adminMenuBuilder.Assembly.FullName}");
            var instance = (IAdminMenuBuilder) Activator.CreateInstance(adminMenuBuilder);
            var menuItems = instance.BuildMenu();

            foreach (var item in menuItems)
            {
                cache.AdminItems.Add(item);
            }
        }

        private static void BuildMenu(Assembly assembly, IMenuCache cache)
        {
            var adminMenuBuilder =
                assembly.ExportedTypes.FirstOrDefault(_ =>
                    _.IsInterface == false && typeof(IMenuBuilder).IsAssignableFrom(_));
            if (adminMenuBuilder == null)
            {
                return;
            }

            InternalLogger.Log($"Building menu for module {adminMenuBuilder.Assembly.FullName}");
            var instance = (IMenuBuilder) Activator.CreateInstance(adminMenuBuilder);
            var menuItems = instance.BuildMenu();

            foreach (var item in menuItems)
            {
                cache.Items.Add(item);
            }
        }
    }
}