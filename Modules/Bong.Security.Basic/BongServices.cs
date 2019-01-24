using Microsoft.Extensions.DependencyInjection;

namespace Bong.Security.Basic
{
    public class BongServices
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient(typeof(IAuthenticationLogic), provider =>
            {
                var service = provider.GetService<IAuthenticationProvider>();
                return (IAuthenticationLogic) service;
            });
        }
    }
}