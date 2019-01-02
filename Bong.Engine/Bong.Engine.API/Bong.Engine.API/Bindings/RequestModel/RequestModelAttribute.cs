using System;
using Microsoft.Azure.WebJobs.Description;

namespace Bong.Engine.API.Bindings.RequestModel
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class RequestModelAttribute : Attribute
    {
    }
}