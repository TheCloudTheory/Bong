using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.Engine.API.Modules.Pages
{
    public static partial class Pages
    {
        public class PagesEntity : TableEntity
        {
            public string Title { get; set; }
            public string Body { get; set; }
            public DateTimeOffset DateCreated { get; set; }
        }
    }
}
