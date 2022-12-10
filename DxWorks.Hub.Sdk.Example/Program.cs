using DxWorks.Hub.Sdk;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

serviceCollection.AddDxWorksHubSdk();

var serviceProvider = serviceCollection.BuildServiceProvider();

var dxWorksHubClient = serviceProvider.GetRequiredService<IDxWorksHubClient>();

dxWorksHubClient.UpdateRepository();

var dxWorksProjects = dxWorksHubClient.GetProjects();

foreach (var dxWorksProject in dxWorksProjects)
{
    Console.WriteLine(dxWorksProject);
}
