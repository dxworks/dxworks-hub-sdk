namespace DxWorks.Hub.Sdk.Project;

public static class ScriptBeeProjectTypes
{
    public const string Plugin = "plugin";
    public const string Bundle = "bundle";
}

public record ScriptBeeProject(
    string Id,
    string Name,
    string Type,
    string Description,
    string License,
    List<string> Repositories,
    List<string> Issues,
    List<string> Docs,
    string Site,
    List<string> Technologies,
    List<string> Tags,
    List<Author> Authors,
    List<ScriptBeeProjectVersion> Versions
)
{
    public ScriptBeeProject() : this(null!, null!, null!,
        null!, null!, new(),
        new(), new(), null!,
        new(), new(), new(), new())
    {
    }
}

public record ScriptBeeProjectVersion(
    Version Version,
    string SourceCode,
    string Manifest,
    string DownloadUrl
)
{
    public ScriptBeeProjectVersion() : this(null!, null!, null!, null!)
    {
    }
}
