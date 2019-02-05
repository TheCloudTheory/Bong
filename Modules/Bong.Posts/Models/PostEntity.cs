using System;
using Bong.Posts.ViewModels;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.Posts.Models
{
    public class PostEntity : TableEntity
    {
        public PostEntity()
        {
            PartitionKey = "post";
        }

        public PostEntity(PostViewModel model)
            : this()
        {
            RowKey = model.Url;
            Title = model.Title;
            Url = model.Url;
            Body = model.Body;
            DateCreated = DateTimeOffset.Now;
        }

        public string Title { get; set; }
        public string Url { get; set; }
        public string Body { get; set; }
        public DateTimeOffset DateCreated { get;set; }
    }
}