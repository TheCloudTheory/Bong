using System;
using System.Linq;
using Bong.Common;

namespace Bong.Menu
{
    public class BongStartup
    {
        public void Configure(IBongContext ctx)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (ctx.LoadedModules.Any(_ => _.Module == assembly.GetName().Name))
                {
                    var builder =
                        assembly.ExportedTypes.FirstOrDefault(_ =>
                            _.IsInterface == false && typeof(IAdminMenuBuilder).IsAssignableFrom(_));
                    if (builder == null)
                    {
                        continue;
                    }

                    InternalLogger.Log($"Building admin menu for module {builder.Assembly.FullName}");
                    var instance = (IAdminMenuBuilder)Activator.CreateInstance(builder);
                    var menuItems = instance.BuildMenu();

                    foreach (var item in menuItems)
                    {
                        AdminMenuCache.Items.Add(item);
                    }
                }
            }
        }
    }
}