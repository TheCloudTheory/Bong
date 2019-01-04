using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.Portal.Core.Storage
{
    public class StorageProvider
    {
        private static CloudTableClient _client;

        static StorageProvider()
        {
            var account = CloudStorageAccount.Parse("UseDevelopmentAccount=true");
            _client = account.CreateCloudTableClient();
        }


    }
}
