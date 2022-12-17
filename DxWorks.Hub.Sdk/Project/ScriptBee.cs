namespace DxWorks.Hub.Sdk.Project;

public record ScriptBee(string? Id, string Type, List<ScriptBeeVersion> Versions)
{
    public ScriptBee() : this(null!, null!, new List<ScriptBeeVersion>())
    {
    }
}

public record ScriptBeeVersion(
    Version Version,
    string Name,
    string SourceCode,
    string Manifest,
    string Asset
)
{
    public ScriptBeeVersion() : this(null!, null!, null!, null!, null!)
    {
    }
}
