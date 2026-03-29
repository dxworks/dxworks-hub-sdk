# DxWorks Hub SDK

This is the API for the DxWorks Hub SDK. It contains the interfaces and classes that are used by the Hub SDK to
communicate with
the [DxWorks Hub](https://github.com/dxworks/dxworks-hub.git).

It downloads the git repository and works with the files and folders from there.

## Usage

### Add to Dependency Injection

```csharp
services.AddDxWorksHubSdk();
```

### Configuration

- `RepositoryUrl`: The URL of the git repository to download. Default is "https://github.com/dxworks/dxworks-hub.git"
- `MainBranch`: The name of the main branch. Default is "main"
- `HubDownloadFolder`: The download folder of the repository data. Default is "{UserFolder}/.dxw/hub"

example to configure

```csharp
serviceCollection.AddDxWorksHubSdk(options =>
{
    options.HubDownloadFolder = "path/to/folder";
});
```

### Update repository

```csharp
IDxWorksHubClient client;

client.UpdateRepository();
```

```csharp
IDxWorksHubClient client;

await client.UpdateRepositoryAsync();
```

### Get Projects

```csharp
IDxWorksHubClient client;

IEnumerable<DxWorksProject> projects = client.GetProjects();
```

## Pack

```shell
dotnet pack -c Release -o pack -p:PackageVersion=1.0.0
```
