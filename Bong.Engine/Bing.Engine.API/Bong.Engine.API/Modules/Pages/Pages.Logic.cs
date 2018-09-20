using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    }
}
