using Bong.Engine.API.Bindings;
using Bong.Engine.API.Bindings.RequestModel;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(BongStartup))]

namespace Bong.Engine.API.Bindings
{
    public class BongStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddExtension<RequestModelExtensionConfigProvider>();
        }
    }
}