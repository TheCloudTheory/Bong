using Microsoft.AspNetCore.Mvc.Razor;
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
                options.ViewLocationFormats.Add("/Themes/Bong.Default/views/{0}" + RazorViewEngine.ViewExtension);
                options.ViewLocationFormats.Add("/Themes/Bong.Default/views/Shared/{0}" + RazorViewEngine.ViewExtension);
                options.ViewLocationFormats.Add("/Themes/Bong.Default/views/Components/{0}" + RazorViewEngine.ViewExtension);
            });
        }
    }
}