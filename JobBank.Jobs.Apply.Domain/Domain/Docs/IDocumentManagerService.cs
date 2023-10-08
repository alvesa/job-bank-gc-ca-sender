namespace JobBank.Jobs.Apply.Domain;
public interface IDocumentManagerService {
    Task SendAsync();
    Task CreateFolderAsync();
    Task FindFolderAsync();
    Task SendJobToFolderAsync();
}