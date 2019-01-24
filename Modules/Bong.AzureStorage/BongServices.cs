using Bong.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Bong.AzureStorage
{
    public class BongServices
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton(typeof(IAzureStorage), provider =>
            {
                var storage = provider.GetService<IStorage>();
                return (IAzureStorage) storage;
            });
            services.AddTransient(typeof(ITableStorageProvider), typeof(TableStorageProvider));
        }
    }
}