using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;

namespace Bong.Engine.API.Bindings.RequestModel
{
    [Extension("BongModelValidation", "Bong")]
    public class RequestModelExtensionConfigProvider : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<RequestModelAttribute>().Bind(new RequestModelBindingProvider());
        }
    }
}