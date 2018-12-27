using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;

namespace Bong.Engine.API.Bindings.TwitterTrigger
{
    [Extension("TwitterTrigger")]
    public class TwitterTriggerExtensionConfigProvider : IExtensionConfigProvider
    {
        private readonly TwitterTriggerTriggerBindingProvider _provider;

        public TwitterTriggerExtensionConfigProvider(TwitterTriggerTriggerBindingProvider provider)
        {
            _provider = provider;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            context.AddBindingRule<TwitterTriggerAttribute>().BindToTrigger(_provider);
        }
    }
}