using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Bong.Portal.Core.Themes
{
    internal sealed class ThemedView : ViewResult
    {
        private string _themeName;

        public ThemedView(string viewName)
        {
            _themeName = "Default";

            ViewName = $"~/wwwroot/themes/{_themeName}/views/{viewName}.cshtml";
        }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var executor = context.HttpContext.RequestServices.GetRequiredService<IActionResultExecutor<ViewResult>>();
            await executor.ExecuteAsync(context, this);
        }
    }
}