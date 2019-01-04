using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Bong.Portal.Core.Themes
{
    internal sealed class ThemedComponentView<TModel> : ThemedComponentView
    {
        public ThemedComponentView(string componentName, TModel model, ViewDataDictionary viewData)
            : base(componentName)
        {
            ViewData = new ViewDataDictionary<TModel>(viewData, model);
        }
    }

    internal class ThemedComponentView : ViewViewComponentResult
    {
        private string _themeName;

        public ThemedComponentView(string componentName)
        {
            _themeName = "Default";

            ViewName = $"~/wwwroot/themes/{_themeName}/views/Components/{componentName}.cshtml";
        }
    }
}
