using System.Linq;
using System.Threading.Tasks;
using Bong.Engine.API.Bindings.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.Engine.API.Modules.Posts
{
    public static partial class Posts
    {
        [FunctionName("Posts_List")]
        public static async Task<IActionResult> Posts_List(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "posts")]HttpRequest req, 
            [Table(TableName, Connection = Constants.ConnectionName)] CloudTable table)
        {
            var result = (await Repository.List<PostEntity>(table)).Select(_ => new
            {
                Id = _.RowKey,
                Title = _.Title,
                Url = _.Url,
                DateCreated = _.DateCreated
            });

            return new JsonResult(result);
        }

        [FunctionName("Posts_Create")]
        public static async Task<IActionResult> Posts_Create(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "posts")]HttpRequest req, 
            [Table(TableName, Connection = Constants.ConnectionName)] CloudTable table,
            [RequestModel] RequestModel<PostEntity> model)
        {
            if (model.IsNotValid)
            {
                return model.CreateBadRequestResponse();
            }

            await Repository.Create(table, model.Model);
            return new CreatedResult("", model);
        }

        [FunctionName("Posts_Get")]
        public static async Task<IActionResult> Posts_Get(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "posts/{id}")]HttpRequest req, 
            string id,
            [Table(TableName, Connection = Constants.ConnectionName)] CloudTable table)
        {
            var result = await Repository.Get<PostEntity>(table, id, PartitionKey);
            return new JsonResult(result.Result);
        }

        [FunctionName("Posts_Delete")]
        public static async Task<IActionResult> Posts_Delete(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "posts/{id}")]HttpRequest req, 
            string id,
            [Table(TableName, Connection = Constants.ConnectionName)] CloudTable table)
        {
            await Repository.Delete<PostEntity>(table, id, PartitionKey);
            return new OkResult();
        }

        [FunctionName("Posts_Edit")]
        public static async Task<IActionResult> Posts_Edit(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "posts/{id}")]HttpRequest req, 
            string id,
            [Table(TableName, Connection = Constants.ConnectionName)] CloudTable table,
            [RequestModel] RequestModel<PostEntity> model)
        {
            if (model.IsNotValid)
            {
                return model.CreateBadRequestResponse();
            }

            await Repository.Update(table, id, PartitionKey, model, (post, requestModel) =>
            {
                var validatedModel = model.Model;

                post.Body = validatedModel.Body;
                post.Title = validatedModel.Title;
                post.Url = validatedModel.Url;
                post.Subtitle = validatedModel.Subtitle;

                return post;
            });

            return new NoContentResult();
        }
    }
}
