using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.Posts.Models
{
    public class PostEntity : TableEntity
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Body { get; set; }
        public DateTimeOffset DateCreated { get;set; }
    }
}