namespace DxWorks.Hub.Sdk.Project;

public record Symphony(List<SymphonyVersion> Versions)
{
    public Symphony() : this(new List<SymphonyVersion>())
    {
    }
}

public record SymphonyVersion(Version Version, string Name, string Compose)
{
    public SymphonyVersion() : this(null!, null!, null!)
    {
    }
}
