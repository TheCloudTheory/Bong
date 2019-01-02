namespace Bong.Engine.API.Modules.Authentication
{
    public static partial class Authentication
    {
        public const string TableName = "Settings";
        public static readonly string PartitionKey = nameof(Authentication).ToLower();
    }
}
