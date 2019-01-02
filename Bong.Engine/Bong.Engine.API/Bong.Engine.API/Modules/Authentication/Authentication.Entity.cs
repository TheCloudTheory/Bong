using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.Engine.API.Modules.Authentication
{
    public static partial class Authentication
    {
        public class AuthenticationEntity : TableEntity
        {
            public AuthenticationEntity(string name)
            {
                PartitionKey = Authentication.PartitionKey;
                RowKey = name;
            }

            public string Value { get; set; }
        }

        public class AuthenticationModelEntity
        {
            [Required]
            public int AuthenticationType { get; set; }

            public IDictionary<string, object> GetFieldsAndValues()
            {
                var dict = GetType().GetProperties()
                    .ToDictionary(property => property.Name, property => property.GetValue(this));

                return dict;
            }
        }
    }
}
