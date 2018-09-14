using System.Threading.Tasks;
using Bong.Engine.API.Bindings.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.Engine.API.Modules.Pages
{
    public static partial class Pages
    {
        [FunctionName("Pages_List")]
        public static async Task<IActionResult> Pages_List(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "page")]HttpRequest req, 
            [Table(TableName, Connection = Constants.ConnectionName)] CloudTable table)
        {
            var result = await GetPages(table);
            return new JsonResult(result);
        }

        [FunctionName("Pages_Create")]
        public static async Task<IActionResult> Pages_Create(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "page")]HttpRequest req, 
            [Table(TableName, Connection = Constants.ConnectionName)] CloudTable table,
            [RequestModel] RequestModel<PagesEntity> model)
        {
            await CreatePage(table);
            return new CreatedResult("", "");
        }
    }
}
