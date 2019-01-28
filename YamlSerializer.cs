using Bong.Common;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Bong
{
    public class YamlSerializer : IYamlSerializer
    {
        private readonly IDeserializer _deserializer;
        private readonly ISerializer _serializer;

        internal YamlSerializer()
        {
            _deserializer = new DeserializerBuilder().WithNamingConvention(new CamelCaseNamingConvention()).Build();
            _serializer = new SerializerBuilder().WithNamingConvention(new CamelCaseNamingConvention()).Build();
        }

        public T Deserialize<T>(string input)
        {
            return _deserializer.Deserialize<T>(input);
        }

        public string Serialize(object input)
        {
            return _serializer.Serialize(input);
        }
    }
}