using System.Collections.Generic;
using System.Reflection;
using LinqToTwitter;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Triggers;

namespace Bong.Engine.API.Bindings.TwitterTrigger
{
    public class TwitterTriggerData : ITriggerData
    {
        private readonly List<Status> _statuses;
        private readonly ParameterInfo _parameter;

        public TwitterTriggerData(List<Status> statuses, ParameterInfo parameter)
        {
            _statuses = statuses;
            _parameter = parameter;
        }

        public IValueProvider ValueProvider => new TwitterTriggerValueProvider(_parameter, _statuses);
        public IReadOnlyDictionary<string, object> BindingData { get; }
    }
}