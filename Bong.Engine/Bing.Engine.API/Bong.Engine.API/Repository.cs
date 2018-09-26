using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bong.Engine.API.Bindings.RequestModel;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.Engine.API
{
    public class Repository
    {
        public static async Task<IEnumerable<T>> List<T>(CloudTable table) where T : ITableEntity, new()
        {
            var query = new TableQuery<T>();

            var result = await table.ExecuteQuerySegmentedAsync(query, new TableContinuationToken());
            return result;
        }

        public static Task<TableResult> Create<T>(CloudTable table, T entity)where T : ITableEntity
        {
            var op = TableOperation.Insert(entity);
            return table.ExecuteAsync(op);
        }

        public static Task<TableResult> Get<T>(CloudTable table, string id, string partitionKey) where T : ITableEntity, new()
        {
            var op = TableOperation.Retrieve<T>(partitionKey, id);
            return table.ExecuteAsync(op);
        }

        public static async Task<TableResult> Delete<T>(CloudTable table, string id, string partitionKey) where T : ITableEntity, new()
        {
            var entity = await Get<T>(table, id, partitionKey);
            var result = await table.ExecuteAsync(TableOperation.Delete(entity.Result as ITableEntity));

            return result;
        }

        public static async Task<TableResult> Update<T>(CloudTable table, string id, string partitionKey,
            RequestModel<T> model, Func<T, RequestModel<T>, T> updateFunc) where T : ITableEntity, new()
        {
            var entity = await Get<T>(table, id, partitionKey);
            var updatedEntity = updateFunc((T) entity.Result, model);
            var result = await table.ExecuteAsync(TableOperation.Replace(updatedEntity));

            return result;
        }
    }
}