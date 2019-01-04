using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Bong.Portal.Core.Themes
{
    internal sealed class ThemedComponentView : ViewViewComponentResult
    {
        private string _themeName;

        public ThemedComponentView(string componentName)
        {
            _themeName = "Default";

            ViewName = $"~/wwwroot/themes/{_themeName}/views/Components/{componentName}.cshtml";
        }
    }
}
