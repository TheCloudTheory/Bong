using Bong.Engine.API.Bindings;
using Bong.Engine.API.Bindings.RequestModel;
using Bong.Engine.API.Bindings.TwitterTrigger;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection.Extensions;

[assembly: WebJobsStartup(typeof(BongStartup))]

namespace Bong.Engine.API.Bindings
{
    public class BongStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddExtension<TwitterTriggerExtensionConfigProvider>();
            builder.AddExtension<RequestModelExtensionConfigProvider>();

            builder.Services.TryAddSingleton<TwitterTriggerTriggerBindingProvider>();
        }
    }
}