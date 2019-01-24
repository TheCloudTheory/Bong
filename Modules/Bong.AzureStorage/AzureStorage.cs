using Bong.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.AzureStorage
{
    public class AzureStorage : IStorage, IAzureStorage
    {
        private readonly IConfigurationRoot _configuration;
        
        public CloudTableClient TableClient { get; private set; }

        public AzureStorage(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public void Initialize()
        {
            var connectionString = _configuration.GetConnectionString("Bong.AzureStorage");
            var account = CloudStorageAccount.Parse(connectionString);

            TableClient = account.CreateCloudTableClient();
        }
    }
}