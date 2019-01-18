﻿using Bong.Storage;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.AzureStorage
{
    public class AzureStorage : IStorage
    {
        private CloudTableClient _tableClient;

        public void Initialize()
        {
            var account = CloudStorageAccount.Parse("UseDevelopmentStorage=true");

            _tableClient = account.CreateCloudTableClient();
        }
    }
}