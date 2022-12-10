using YamlDotNet.Serialization;

namespace DxWorks.Hub.Sdk.Project;

public record Voyager(List<VoyagerVersion> Versions)
{
    public Voyager() : this(new List<VoyagerVersion>())
    {
    }
}

public record VoyagerVersion(
    Version Version,
    string Name,
    string Tag,
    string Asset,
    bool Online,
    [property: YamlMember(Alias = "instrument-yaml")]
    string? InstrumentYaml
)
{
    public VoyagerVersion() : this(null!, null!, null!, null!, false, null)
    {
    }
}
