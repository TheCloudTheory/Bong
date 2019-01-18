using System;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Bong.Common
{
    internal interface IDataDeserializer
    {
        T Deserialize<T>(string fileName);
    }

    internal class DataDeserializer : IDataDeserializer
    {
        private readonly Lazy<IDeserializer> _deserializer = new Lazy<IDeserializer>(() =>
            new DeserializerBuilder().WithNamingConvention(new CamelCaseNamingConvention()).Build());

        public T Deserialize<T>(string fileName)
        {
            var mainDirectory = Directory.GetCurrentDirectory();
            var modulesFile = Path.Combine(mainDirectory, "Data", $"{fileName}.yaml");
            var fileContent = File.ReadAllText(modulesFile);
            var value = _deserializer.Value.Deserialize<T>(fileContent);

            return value;
        }
    }
}