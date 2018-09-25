using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace Bong.Engine.API.Modules.Pages
{
    public static partial class Pages
    {
        public class PageEntity : TableEntity
        {
            public PageEntity()
            {
                PartitionKey = Posts.Posts.PartitionKey;
                RowKey = Guid.NewGuid().ToString();
            }

            [Required]
            public string Title { get; set; }
            [Required]
            public string Url { get; set; }
            [Required]
            public string Body { get; set; }
            [JsonIgnore]
            public DateTimeOffset DateCreated { get; set; }
        }
    }
}
