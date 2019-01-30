using Microsoft.Extensions.DependencyInjection;

namespace Bong.Menu
{
    public class BongServices
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton(typeof(IMenuCache), typeof(MenuCache));
        }
    }
}