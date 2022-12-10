using DxWorks.Hub.Sdk.Project;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace DxWorks.Hub.Sdk.Internals;

internal static class ManifestReader
{
    public static DxWorksProject ReadManifest(string manifestPath)
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .IgnoreUnmatchedProperties()
            .Build();

        var content = File.ReadAllText(manifestPath);
        return deserializer.Deserialize<DxWorksProject>(content);
    }
}
