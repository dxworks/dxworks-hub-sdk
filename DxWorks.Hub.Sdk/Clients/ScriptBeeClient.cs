using DxWorks.Hub.Sdk.Project;
using Microsoft.Extensions.Options;

namespace DxWorks.Hub.Sdk.Clients;

internal sealed class ScriptBeeClient : DxWorksHubClient, IScriptBeeClient
{
    public ScriptBeeClient(IOptions<DxWorksHubSdkOptions> options) : base(options)
    {
    }

    public IEnumerable<ScriptBeeProject> GetScriptBeeProjects()
    {
        return GetRawProjects()
            .Where(project => project.ScriptBee is not null)
            .Select(project =>
            {
                var id = project.ScriptBee!.Id ?? project.Slug;
                var type = project.ScriptBee.Type;
                var versions = project.ScriptBee.Versions.Select(GetScriptBeeProjectVersion).ToList();

                return new ScriptBeeProject(id, project.Name, type, project.Description, project.License,
                    project.Repositories, project.Issues, project.Docs, project.Site, project.Technologies,
                    project.Tags, project.Authors, versions);
            });
    }

    private static ScriptBeeProjectVersion GetScriptBeeProjectVersion(ScriptBeeVersion scriptBeeVersion)
    {
        var downloadUrl = GetDownloadUrl(scriptBeeVersion.Name, scriptBeeVersion.Version, scriptBeeVersion.Asset);

        return new ScriptBeeProjectVersion(scriptBeeVersion.Version, scriptBeeVersion.SourceCode,
            scriptBeeVersion.Manifest, downloadUrl);
    }

    private static string GetDownloadUrl(string name, Version version, string asset)
    {
        return $"https://github.com/{name}/releases/download/v{version}/{asset}";
    }
}
