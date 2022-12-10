namespace DxWorks.Hub.Sdk.Project;

public record Author(string Name, string Email)
{
    public Author() : this(null!, null!)
    {
    }
}
