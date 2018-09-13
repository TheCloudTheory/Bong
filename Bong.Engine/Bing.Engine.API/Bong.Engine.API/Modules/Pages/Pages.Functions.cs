using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.Engine.API.Modules.Pages
{
    public static partial class Pages
    {
        [FunctionName("Pages_List")]
        public static async Task<IActionResult> Pages_List(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "page")]HttpRequest req, 
            [Table(TableName, Connection = Constants.ConnectionName)] CloudTable table,
            ILogger log)
        {
            var result = await GetPages(table);
            return new JsonResult(result);
        }
    }
}
