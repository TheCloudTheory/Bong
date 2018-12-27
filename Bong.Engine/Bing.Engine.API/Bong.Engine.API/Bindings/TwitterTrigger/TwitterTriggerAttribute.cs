using System;
using Microsoft.Azure.WebJobs.Description;

namespace Bong.Engine.API.Bindings.TwitterTrigger
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding(TriggerHandlesReturnValue = true)]
    public class TwitterTriggerAttribute : Attribute
    {
    }
}