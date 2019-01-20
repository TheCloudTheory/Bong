using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.AzureStorage
{
    public interface ITableStorageProvider
    {
        Task<IEnumerable<T>> List<T>(string tableName) where T : TableEntity, new();

        Task<bool> Create<T>(T enitty, string tableName) where T : TableEntity, new();
    }

    public class TableStorageProvider : ITableStorageProvider
    {
        private readonly CloudTableClient _tableClient;

        public TableStorageProvider()
        {
            var account = CloudStorageAccount.Parse("UseDevelopmentStorage=true");

            _tableClient = account.CreateCloudTableClient();
        }

        public async Task<IEnumerable<T>> List<T>(string tableName) where T : TableEntity, new()
        {
            var reference = _tableClient.GetTableReference(tableName);
            await CreateTableIfNotExist(reference);

            var query = new TableQuery<T>();
            var result = await reference.ExecuteQuerySegmentedAsync(query, new TableContinuationToken());

            return result.Results;
        }

        public async Task<bool> Create<T>(T enitty, string tableName) where T : TableEntity, new()
        {
            var reference = _tableClient.GetTableReference(tableName);
            await CreateTableIfNotExist(reference);

            var op = TableOperation.Insert(enitty);
            var result = await reference.ExecuteAsync(op);

            return result.HttpStatusCode <= 299;
        }

        private static Task CreateTableIfNotExist(CloudTable table)
        {
            return table.CreateIfNotExistsAsync();
        }
    }
}