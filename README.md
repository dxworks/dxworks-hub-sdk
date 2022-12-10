# DxWorks Hub SDK

This is the API for the DxWorks Hub SDK. It contains the interfaces and classes that are used by the Hub SDK to communicate with
the [DxWorks Hub](https://github.com/dxworks/dxworks-hub.git).

It downloads the git repository and works with the files and folders from there.

## Usage

### Add to Dependency Injection

```csharp
services.AddDxWorksHubSdk();
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
