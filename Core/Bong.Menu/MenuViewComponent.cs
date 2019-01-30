using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bong.Menu
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IMenuCache _cache;

        public MenuViewComponent(IMenuCache cache)
        {
            _cache = cache;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            
            return Task.FromResult<IViewComponentResult>(View("Menu", _cache.Items));
        }
    }
}