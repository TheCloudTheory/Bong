using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host.Bindings;

namespace Bong.Engine.API.Bindings.RequestModel
{
    public class RequestModelValueBinder : IValueBinder
    {
        private readonly HttpRequest _req;
        private readonly ParameterInfo _parameter;

        public RequestModelValueBinder(ParameterInfo parameter, HttpRequest req)
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
            var instance = Activator.CreateInstance(generic, GetRequestBodyAsString(_req.Body).Result);

            return Task.FromResult(instance);
        }

        private async Task<string> GetRequestBodyAsString(Stream stream)
        {
            using (var sr = new StreamReader(stream))
            {
                var text = await sr.ReadToEndAsync();
                return text;
            }
        }
    }
}