using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Bong.Engine.API.Modules.Pages
{
    public static partial class Pages
    {
        [FunctionName("Pages_List")]
        public static IActionResult Pages_List(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "pages")]HttpRequest req, 
            [Table(TableName, Connection = Constants.ConnectionName)] IQueryable<PagesEntity> pages,
            ILogger log)
        {
            return new OkResult();
        }
    }
}
