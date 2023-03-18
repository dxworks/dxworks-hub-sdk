using DxWorks.Hub.Sdk.Internals;
using DxWorks.Hub.Sdk.Project;
using Microsoft.Extensions.Options;

namespace DxWorks.Hub.Sdk.Clients;

internal class DxWorksHubClient : IDxWorksHubClient
{
    private readonly RepositoryManager _repositoryManager;

    public DxWorksHubClient(IOptions<DxWorksHubSdkOptions> options)
    {
        var sdkOptions = options.Value;

        _repositoryManager = new RepositoryManager(sdkOptions.RepositoryUrl, ConfigFolder.GetHubFolder());
    }

    public void RemoveRepository()
    {
        _repositoryManager.RemoveRepository();
    }

    public void UpdateRepository()
    {
        if (_repositoryManager.IsRepositoryInitialized())
        {
            _repositoryManager.UpdateRepository();
        }
        else
        {
            _repositoryManager.DownloadRepository();
        }
    }

    public async Task UpdateRepositoryAsync(CancellationToken cancellationToken = default)
    {
        if (_repositoryManager.IsRepositoryInitialized())
        {
            await _repositoryManager.UpdateRepositoryAsync(cancellationToken);
        }
        else
        {
            await _repositoryManager.DownloadRepositoryAsync(cancellationToken);
        }
    }

    public IEnumerable<DxWorksProject> GetRawProjects()
    {
        return _repositoryManager.GetProjects();
    }
}
