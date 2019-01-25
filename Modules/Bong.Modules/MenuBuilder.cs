using System.Collections.Generic;
using Bong.Menu;

namespace Bong.Modules
{
    public class MenuBuilder : IAdminMenuBuilder
    {
        public IEnumerable<MenuItem> BuildMenu()
        {
            return new[]
            {
                new MenuItem("Bong.Modules.List", "Modules", "admin/modules", UrlKind.Relative)
            };
        }
    }
}