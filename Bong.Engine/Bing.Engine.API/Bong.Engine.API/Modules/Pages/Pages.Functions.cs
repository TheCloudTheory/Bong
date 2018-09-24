using System.Linq;
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
            var result = (await GetPages(table)).Select(_ => new
            {
                Id = _.RowKey,
                Title = _.Title,
                Url = _.Url,
                DateCreated = _.DateCreated
            });

            return new JsonResult(result);
        }

        [FunctionName("Pages_Create")]
        public static async Task<IActionResult> Pages_Create(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "page")]HttpRequest req, 
            [Table(TableName, Connection = Constants.ConnectionName)] CloudTable table,
            [RequestModel] RequestModel<PageEntity> model)
        {
            if (model.IsNotValid)
            {
                return model.CreateBadRequestResponse();
            }

            await CreatePage(table, model.Model);
            return new CreatedResult("", model);
        }

        [FunctionName("Pages_Get")]
        public static async Task<IActionResult> Pages_Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "page/{id}")]HttpRequest req, 
            string id,
            [Table(TableName, Connection = Constants.ConnectionName)] CloudTable table)
        {
            var result = await GetPage(id, table);
            return new JsonResult(result.Result);
        }

        [FunctionName("Pages_Delete")]
        public static async Task<IActionResult> Pages_Delete(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "page/{id}")]HttpRequest req, 
            string id,
            [Table(TableName, Connection = Constants.ConnectionName)] CloudTable table)
        {
            await DeletePage(id, table);
            return new OkResult();
        }

        [FunctionName("Pages_Edit")]
        public static async Task<IActionResult> Pages_Edit(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "page/{id}")]HttpRequest req, 
            string id,
            [Table(TableName, Connection = Constants.ConnectionName)] CloudTable table,
            [RequestModel] RequestModel<PageEntity> model)
        {
            if (model.IsNotValid)
            {
                return model.CreateBadRequestResponse();
            }

            await UpdatePage(id, table, model);
            return new NoContentResult();
        }
    }
}
