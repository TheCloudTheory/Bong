using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bong.Menu
{
    public class AdminMenuViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            
            return Task.FromResult<IViewComponentResult>(View("AdminMenu"));
        }
    }
}