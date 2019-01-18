using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.AzureStorage
{
    public interface ITableStorageProvider
    {

    }

    public class TableStorageProvider : ITableStorageProvider
    {
        private CloudTableClient _tableClient;

        public TableStorageProvider()
        {
            var account = CloudStorageAccount.Parse("UseDevelopmentStorage=true");

            _tableClient = account.CreateCloudTableClient();
        }
    }
}