using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.Engine.API.Modules.Pages
{
    public static partial class Pages
    {
        public static async Task<IEnumerable<PagesEntity>> GetPages(CloudTable table)
        {
            var query = new TableQuery<PagesEntity>();
            var result = await table.ExecuteQuerySegmentedAsync(query, new TableContinuationToken());

            return result;
        }
    }
}
