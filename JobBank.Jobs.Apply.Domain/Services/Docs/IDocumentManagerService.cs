using JobBank.Jobs.Apply.Domain.Models;

namespace JobBank.Jobs.Apply.Domain;
public interface IDocumentManagerService {
    Task CreateFolderAsync();
    Task FindFolderAsync();
    Task SendJobToFolderAsync(JobDTO job);
}