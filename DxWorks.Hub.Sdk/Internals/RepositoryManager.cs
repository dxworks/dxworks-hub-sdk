using DxWorks.Hub.Sdk.Project;
using LibGit2Sharp;

namespace DxWorks.Hub.Sdk.Internals;

internal class RepositoryManager
{
    private readonly string _repositoryPath;
    private readonly string _workingDirectory;

    public RepositoryManager(string repositoryPath, string workingDirectory)
    {
        _repositoryPath = repositoryPath;
        _workingDirectory = workingDirectory;
    }

    public bool IsRepositoryInitialized()
    {
        var folderExists = Directory.Exists(Path.Combine(_workingDirectory));

        return folderExists && Repository.IsValid(_workingDirectory);
    }

    public void DownloadRepository()
    {
        Repository.Clone(_repositoryPath, _workingDirectory);
    }

    public Task DownloadRepositoryAsync(CancellationToken cancellationToken = default)
    {
        return Task.Run(DownloadRepository, cancellationToken);
    }

    public void UpdateRepository()
    {
        using var repository = new Repository(_workingDirectory);

        var branch = repository.Branches["origin/main"];

        if (branch is not null)
        {
            Commands.Checkout(repository, branch, new CheckoutOptions
            {
                CheckoutModifiers = CheckoutModifiers.Force
            });
        }
    }

    public Task UpdateRepositoryAsync(CancellationToken cancellationToken = default)
    {
        return Task.Run(UpdateRepository, cancellationToken);
    }

    public void RemoveRepository()
    {
        Directory.Delete(_workingDirectory, true);
    }

    public IEnumerable<DxWorksProject> GetProjects()
    {
        var projects = Directory.GetFiles(ConfigFolder.GetProjectsFolder(_workingDirectory));

        return projects.Select(ManifestReader.ReadManifest);
    }
}
