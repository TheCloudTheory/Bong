using Microsoft.Extensions.DependencyInjection;

namespace Bong.Storage
{
    public class BongServices
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient(typeof(IStorageProvider), typeof(StorageProvider));
        }
    }
}