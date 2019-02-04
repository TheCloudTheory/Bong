using System.Collections.Generic;
using Bong.Menu;

namespace Bong.Pages
{
    public class MenuBuilder : IAdminMenuBuilder
    {
        public IEnumerable<MenuItem> BuildMenu()
        {
            return new[]
            {
                new MenuItem("Bong.Pages.List", "Pages", "admin/pages", UrlKind.Relative)
            };
        }
    }
}