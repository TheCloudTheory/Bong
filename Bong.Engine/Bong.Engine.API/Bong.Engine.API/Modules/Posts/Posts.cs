namespace Bong.Engine.API.Modules.Posts
{
    public static partial class Posts
    {
        public const string TableName = nameof(Posts);
        public static readonly string PartitionKey = nameof(Posts).ToLower();
    }
}
