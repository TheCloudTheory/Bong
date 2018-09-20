using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bong.Engine.API.Bindings.RequestModel
{
    public sealed class RequestModel<TModel>
    {
        private readonly string _payload;

        public RequestModel(string payload)
        {
            _payload = payload;
        }

        public TModel Model => ModelLazy.Value;
        private Lazy<TModel> ModelLazy => new Lazy<TModel>(() => JsonConvert.DeserializeObject<TModel>(_payload));

        public bool IsNotValid => IsValidLazy.Value != true;
        private Lazy<bool> IsValidLazy => new Lazy<bool>(() =>
        {
            var instance = ModelLazy.Value;
            var context = new ValidationContext(instance);
            return Validator.TryValidateObject(instance, context, ValidationResults);
        });

        public ICollection<ValidationResult> ValidationResults => new List<ValidationResult>();

        public BadRequestResult CreateBadRequestResponse()
        {
            return new BadRequestResult();
        }

        public HttpResponseMessage CreateBadRequestResponse(string errorMessage)
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(errorMessage)
            };
        }
    }
}