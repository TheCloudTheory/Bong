using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bong.Engine.API.Bindings.RequestModel;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.Engine.API.Modules.Pages
{
    public static partial class Pages
    {
        public static async Task<IEnumerable<PageEntity>> GetPages(CloudTable table)
        {
            var query = new TableQuery<PageEntity>().Select(new List<string>
            {
                nameof(PageEntity.RowKey),
                nameof(PageEntity.Title),
                nameof(PageEntity.Url),
                nameof(PageEntity.DateCreated)
            });

            var result = await table.ExecuteQuerySegmentedAsync(query, new TableContinuationToken());
            return result;
        }

        public static Task CreatePage(CloudTable table, PageEntity model)
        {
            var entity = new PageEntity
            {
                Body = model.Body,
                Title = model.Title,
                Url = model.Url,
                DateCreated = DateTimeOffset.UtcNow
            };

            var op = TableOperation.Insert(entity);

            return table.ExecuteAsync(op);
        }

        private static async Task<TableResult> GetPage(string id, CloudTable table)
        {
            var op = TableOperation.Retrieve<PageEntity>(PartitionKey, id);
            var result = await table.ExecuteAsync(op);
            return result;
        }

        private static async Task DeletePage(string id, CloudTable table)
        {
            var page = await GetPage(id, table);
            await table.ExecuteAsync(TableOperation.Delete(page.Result as ITableEntity));
        }

        private static async Task UpdatePage(string id, CloudTable table, RequestModel<PageEntity> model)
        {
            var validatedModel = model.Model;
            var page = (PageEntity) (await GetPage(id, table)).Result;
            page.Body = validatedModel.Body;
            page.Title = validatedModel.Title;
            page.Url = validatedModel.Url;

            var op = TableOperation.Replace(page);
            await table.ExecuteAsync(op);
        }
    }
}
