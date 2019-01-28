namespace Bong.Common
{
    public interface IYamlSerializer
    {
        T Deserialize<T>(string input);

        string Serialize(object input);
    }
}