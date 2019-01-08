using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bong.Default.Components
{
    public class MenuViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult<IViewComponentResult>(View("Menu"));
        }
    }
}
