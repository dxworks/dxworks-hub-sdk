using DxWorks.Hub.Sdk.Project;

namespace DxWorks.Hub.Sdk.Clients;

public interface IScriptBeeClient : IDxWorksHubClient
{
    public IEnumerable<ScriptBeeProject> GetScriptBeeProjects();
}
