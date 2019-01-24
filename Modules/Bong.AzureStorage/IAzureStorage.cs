using Microsoft.WindowsAzure.Storage.Table;

namespace Bong.AzureStorage
{
    public interface IAzureStorage
    {
        CloudTableClient TableClient { get; }
    }
}