using DxWorks.Hub.Sdk.Project;

namespace DxWorks.Hub.Sdk;

public interface IDxWorksHubClient
{
    public void RemoveRepository();

    public void UpdateRepository();

    public Task UpdateRepositoryAsync(CancellationToken cancellationToken = default);

    public IEnumerable<DxWorksProject> GetProjects();
}
