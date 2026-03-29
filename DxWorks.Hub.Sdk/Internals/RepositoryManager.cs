using DxWorks.Hub.Sdk.Project;
using LibGit2Sharp;

namespace DxWorks.Hub.Sdk.Internals;

internal class RepositoryManager(string repositoryPath, string workingDirectory, string branchName)
{
    public bool IsRepositoryInitialized()
    {
        var folderExists = Directory.Exists(Path.Combine(workingDirectory));

        return folderExists && Repository.IsValid(workingDirectory);
    }

    public void DownloadRepository()
    {
        Directory.CreateDirectory(workingDirectory);
        Repository.Clone(repositoryPath, workingDirectory, new CloneOptions
        {
            BranchName = branchName
        });
    }

    public async Task DownloadRepositoryAsync(CancellationToken cancellationToken = default)
    {
        await Task.Run(DownloadRepository, cancellationToken);
    }

    public void UpdateRepository()
    {
        using var repository = new Repository(workingDirectory);

        var trackedBranch = repository.Branches[$"origin/{branchName}"];

        if (trackedBranch is null)
        {
            return;
        }
        
        repository.Reset(ResetMode.Hard, trackedBranch.Tip);

        Commands.Checkout(repository, trackedBranch, new CheckoutOptions
        {
            CheckoutModifiers = CheckoutModifiers.Force
        });
    }

    public async Task UpdateRepositoryAsync(CancellationToken cancellationToken = default)
    {
        await Task.Run(UpdateRepository, cancellationToken);
    }

    public void RemoveRepository()
    {
        Directory.Delete(workingDirectory, true);
    }

    public IEnumerable<DxWorksProject> GetProjects()
    {
        var projects = Directory.GetFiles(ConfigFolder.GetProjectsFolder(workingDirectory));

        return projects.Select(ManifestReader.ReadManifest);
    }
}
