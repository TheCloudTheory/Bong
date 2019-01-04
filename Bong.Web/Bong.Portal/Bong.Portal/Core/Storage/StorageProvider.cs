using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.Portal.Core.Storage
{
    public class StorageProvider
    {
        private static CloudTableClient _client;

        static StorageProvider()
        {
            var account = CloudStorageAccount.Parse("UseDevelopmentStorage=true");
            _client = account.CreateCloudTableClient();
        }

        public async Task<List<TEntity>> GetAllAsync<TEntity>(string tableName)
            where TEntity : TableEntity, new()
        {
            var table = _client.GetTableReference(tableName);
            var result =
                await table.ExecuteQuerySegmentedAsync(new TableQuery<TEntity>(), new TableContinuationToken());

            return result.Results;
        }
    }
}
