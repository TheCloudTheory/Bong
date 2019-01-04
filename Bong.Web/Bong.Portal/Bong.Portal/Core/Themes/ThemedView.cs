using Microsoft.AspNetCore.Mvc;

namespace Bong.Portal.Core.Themes
{
    internal sealed class ThemedView : ViewResult
    {
        private string _themeName;

        public ThemedView(string viewName)
        {
            _themeName = "Default";

            ViewName = $"~/wwwroot/themes/{_themeName}/views/{viewName}.cshtml";
        }
    }
}