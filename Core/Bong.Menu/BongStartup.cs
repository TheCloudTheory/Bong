using System;
using System.Linq;
using Bong.Common;
using Microsoft.AspNetCore.Builder;

namespace Bong.Menu
{
    public class BongStartup
    {
        public void Configure(IApplicationBuilder app)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (ModulesState.LoadedModules.Any(_ => _.Module == assembly.GetName().Name))
                {
                    var builder =
                        assembly.ExportedTypes.FirstOrDefault(_ =>
                            _.IsInterface == false && typeof(IAdminMenuBuilder).IsAssignableFrom(_));
                    if (builder == null)
                    {
                        continue;
                    }

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