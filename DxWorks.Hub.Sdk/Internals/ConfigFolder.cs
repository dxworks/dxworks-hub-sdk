namespace DxWorks.Hub.Sdk.Internals;

internal static class ConfigFolder
{
    public static string GetHubFolder()
    {
        var configFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        configFolder = Path.Combine(configFolder, ".dxw");
        configFolder = Path.Combine(configFolder, "hub");
        return configFolder;
    }

    public static string GetProjectsFolder(string hubFolder)
    {
        var projectsFolder = Path.Combine(hubFolder, "projects");
        return projectsFolder;
    }
}
