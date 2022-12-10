namespace DxWorks.Hub.Sdk.Project;

public record DxWorksProject(
    string Slug,
    string Name,
    string Description,
    string License,
    List<string> Repositories,
    List<string> Issues,
    List<string> Docs,
    string Site,
    List<string> Technologies,
    List<string> Tags,
    List<Author> Authors,
    Voyager? Voyager,
    Symphony? Symphony,
    ScriptBee? ScriptBee
)
{
    public DxWorksProject() : this(null!, null!, null!, null!, new(),
        new(), new(), null!, new(), new(),
        new(), null!, null!, null!)
    {
    }
}
