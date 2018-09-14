using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Extensions.Bindings;
using Microsoft.Azure.WebJobs.Host.Bindings;


namespace Bong.Engine.API.Bindings.RequestModel
{
    public class RequestModelValueBinder : IValueBinder
    {
        private readonly HttpRequestMessage _req;
        private readonly ParameterInfo _parameter;

        public RequestModelValueBinder(ParameterInfo parameter, HttpRequestMessage req)
        {
            _req = req;
            _parameter = parameter;
        }

        public string ToInvokeString()
        {
            return nameof(RequestModelValueBinder);
        }

        public Type Type => typeof(RequestModelValueBinder);

        public Task SetValueAsync(object value, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task<object> GetValueAsync()
        {
            var modelType = _parameter.ParameterType.GenericTypeArguments[0];
            var generic = typeof(RequestModel<>).MakeGenericType(modelType);
            var instance = Activator.CreateInstance(generic, _req.Content.ReadAsStringAsync().Result);

            return Task.FromResult(instance);
        }
    }
}