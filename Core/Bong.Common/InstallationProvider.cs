namespace Bong.Common
{
    public interface IInstallationProvider
    {
        Installation Installation { get; }
    }

    internal class InstallationProvider : IInstallationProvider
    {
        public Installation Installation { get; }

        public InstallationProvider(IDataDeserializer deserializer)
        {
            Installation = deserializer.Deserialize<Installation>("installation");
        }
    }
}