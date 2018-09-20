﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Protocols;

namespace Bong.Engine.API.Bindings.RequestModel
{
    public class RequestModelBinding : IBinding
    {
        private readonly ParameterInfo _parameter;

        public RequestModelBinding(ParameterInfo parameter)
        {
            _parameter = parameter;
        }

        public Task<IValueProvider> BindAsync(object value, ValueBindingContext context)
        {
            return Task.FromResult<IValueProvider>(new RequestModelValueBinder(_parameter, (HttpRequest)value));
        }

        public Task<IValueProvider> BindAsync(BindingContext context)
        {
            if (!(context.BindingData["$request"] is HttpRequest req))
            {
                throw new ArgumentNullException("Field `$request` cannot be null!");
            }

            return BindAsync(req, context.ValueContext);
        }

        public ParameterDescriptor ToParameterDescriptor()
        {
            return new ParameterDescriptor();
        }

        public bool FromAttribute => true;
    }
}