using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.AzureStorage
{
    public interface ITableStorageProvider
    {
        Task<IEnumerable<T>> List<T>(string tableName) where T : TableEntity, new();

        Task<bool> Create<T>(T enitty, string tableName) where T : TableEntity, new();

        Task<T> Get<T>(string partitionKey, string rowKey, string tableName) where T : TableEntity, new();

        Task<bool> Exists(string partitionKey, string rowKey, string tableName);

        Task<bool> Save(ITableEntity entity, string tableName);
    }

    public class TableStorageProvider : ITableStorageProvider
    {
        private readonly CloudTableClient _tableClient;

        public TableStorageProvider(IAzureStorage storage)
        {
            _tableClient = storage.TableClient;
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

        public async Task<T> Get<T>(string partitionKey, string rowKey, string tableName) where T : TableEntity, new()
        {
            var reference = _tableClient.GetTableReference(tableName);
            await CreateTableIfNotExist(reference);

            var op = TableOperation.Retrieve<T>(partitionKey, rowKey);
            var result = await reference.ExecuteAsync(op);

            return result.Result as T;
        }

        public async Task<bool> Exists(string partitionKey, string rowKey, string tableName)
        {
            var reference = _tableClient.GetTableReference(tableName);
            await CreateTableIfNotExist(reference);

            var op = TableOperation.Retrieve(partitionKey, rowKey, new List<string> { "PartitionKey" });
            var result = await reference.ExecuteAsync(op);

            return result.HttpStatusCode > 299;
        }

        public async Task<bool> Save(ITableEntity entity, string tableName)
        {
            var reference = _tableClient.GetTableReference(tableName);
            await CreateTableIfNotExist(reference);

            var op = TableOperation.Replace(entity);
            var result = await reference.ExecuteAsync(op);

            return result.HttpStatusCode <= 299;
        }

        private static Task CreateTableIfNotExist(CloudTable table)
        {
            return table.CreateIfNotExistsAsync();
        }
    }
}