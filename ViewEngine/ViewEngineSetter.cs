﻿using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;

namespace Bong.ViewEngine
{
    public class ViewEngineSetter
    {
        public static void ConfigureBongEcosystem(IServiceCollection services)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationFormats.Clear();
                options.ViewLocationFormats.Add("/Modules/{2}/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
                options.ViewLocationFormats.Add("/Themes/Bong.Default/views/{0}" + RazorViewEngine.ViewExtension);
                options.ViewLocationFormats.Add("/Themes/Bong.Default/views/Shared/{0}" + RazorViewEngine.ViewExtension);
                options.ViewLocationFormats.Add("/Themes/Bong.Default/views/Components/{0}" + RazorViewEngine.ViewExtension);
                options.ViewLocationFormats.Add("/Themes/Bong.Default/views/{0}" + RazorViewEngine.ViewExtension);

                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Modules/{2}/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
                options.AreaViewLocationFormats.Add("/Themes/Bong.Default/views/{0}" + RazorViewEngine.ViewExtension);
                options.AreaViewLocationFormats.Add("/Themes/Bong.Default/views/Shared/{0}" + RazorViewEngine.ViewExtension);
                options.AreaViewLocationFormats.Add("/Themes/Bong.Default/views/Components/{0}" + RazorViewEngine.ViewExtension);
                options.AreaViewLocationFormats.Add("/Themes/Bong.Default/views/{0}" + RazorViewEngine.ViewExtension);

                options.ViewLocationExpanders.Add(new ViewLocationExpander());
            });
        }
    }
}