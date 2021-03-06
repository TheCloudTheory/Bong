﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Bong.Menu
{
    public class AdminMenuViewComponent : ViewComponent
    {
        private readonly IMenuCache _cache;

        public AdminMenuViewComponent(IMenuCache cache)
        {
            _cache = cache;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            
            return Task.FromResult<IViewComponentResult>(View("AdminMenu", _cache.AdminItems));
        }
    }
}