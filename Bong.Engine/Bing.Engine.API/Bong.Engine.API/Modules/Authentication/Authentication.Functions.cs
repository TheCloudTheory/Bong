using System.Threading.Tasks;
using Bong.Engine.API.Bindings.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.Engine.API.Modules.Authentication
{
    public static partial class Authentication
    {
        [FunctionName("Authentication_Fetch")]
        public static IActionResult Authentication_Fetch(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "authentication")]
            HttpRequest req,
            [Table(TableName, Connection = Constants.ConnectionName)] CloudTable table)
        {

            return new OkResult();
        }

        [FunctionName("Authentication_Edit")]
        public static async Task<IActionResult> Authentication_Edit(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "authentication")]
            HttpRequest req,
            [Table(TableName, Connection = Constants.ConnectionName)] CloudTable table,
            [RequestModel] RequestModel<AuthenticationModelEntity> model)
        {
            if (model.IsNotValid)
            {
                return model.CreateBadRequestResponse();
            }

            var fields = model.Model.GetFieldsAndValues();
            foreach (var field in fields)
            {
                await Repository.Update(table, new AuthenticationEntity(field.Key) {Value = field.Value.ToString()});
            }

            return new OkResult();
        }
    }
}
