using DxWorks.Hub.Sdk.Project;

namespace DxWorks.Hub.Sdk.Clients;

public interface IDxWorksHubClient
{
    public void RemoveRepository();

    public void UpdateRepository();

    public Task UpdateRepositoryAsync(CancellationToken cancellationToken = default);

    public IEnumerable<DxWorksProject> GetRawProjects();
}
