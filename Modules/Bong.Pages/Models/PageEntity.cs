using System;
using Bong.Pages.ViewModels;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.Pages.Models
{
    public class PageEntity : TableEntity
    {
        public PageEntity()
        {
            PartitionKey = "post";
            RowKey = Guid.NewGuid().ToString();
        }

        public PageEntity(PageViewModel model)
            : this()
        {
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