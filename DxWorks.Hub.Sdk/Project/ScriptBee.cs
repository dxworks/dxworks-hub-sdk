namespace DxWorks.Hub.Sdk.Project;

public record ScriptBee(List<ScriptBeeVersion> Versions)
{
    public ScriptBee() : this(new List<ScriptBeeVersion>())
    {
    }
}

public record ScriptBeeVersion(
    Version Version,
    string Name,
    string SourceCode,
    string Asset,
    List<ExtensionPoint>? ExtensionPoints,
    Dictionary<string, string>? Requires
)
{
    public ScriptBeeVersion() : this(null!, null!, null!, null!, new(), new())
    {
    }
}

public record ExtensionPoint(string Kind, Version Version)
{
    public ExtensionPoint() : this(null!, null!)
    {
    }
}
