using System.Threading.Tasks;
using Bong.Portal.Core.Themes;
using Microsoft.AspNetCore.Mvc;

namespace Bong.Portal.Components.Ui
{
    public class MenuViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult<IViewComponentResult>(new ThemedComponentView("_Menu"));
        }
    }
}
