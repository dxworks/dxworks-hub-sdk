using DxWorks.Hub.Sdk;
using DxWorks.Hub.Sdk.Clients;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

serviceCollection.AddDxWorksHubSdk();

var serviceProvider = serviceCollection.BuildServiceProvider();

var client = serviceProvider.GetRequiredService<IScriptBeeClient>();

client.UpdateRepository();

var dxWorksProjects = client.GetRawProjects();

foreach (var dxWorksProject in dxWorksProjects)
{
    Console.WriteLine(dxWorksProject);
}

Console.WriteLine();
Console.WriteLine("ScriptBee projects:");
Console.WriteLine();

var scriptBeeProjects = client.GetScriptBeeProjects();

foreach (var scriptBeeProject in scriptBeeProjects)
{
    Console.WriteLine(scriptBeeProject);
    foreach (var version in scriptBeeProject.Versions)
    {
        Console.WriteLine(version.DownloadUrl);
    }
}
