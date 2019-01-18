using Microsoft.Extensions.DependencyInjection;

namespace Bong.AzureStorage
{
    public class BongServices
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton(typeof(ITableStorageProvider), typeof(TableStorageProvider));
        }
    }
}