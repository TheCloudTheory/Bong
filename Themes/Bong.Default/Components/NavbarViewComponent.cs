using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bong.Default.Components
{
    public class NavbarViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult<IViewComponentResult>(View("Navbar"));
        }
    }
}
