
namespace JobBank.Jobs.Apply.Domain;
public class DocumentManagerService : IDocumentManagerService
{
    private readonly IDocumentManagerRepository _documentManagerRepository;

    public DocumentManagerService(IDocumentManagerRepository documentManagerRepository)
    {
        _documentManagerRepository = documentManagerRepository;
    }

    async public Task CreateFolderAsync()
    {
        await Task.Run(() => Console.WriteLine("Creating folder..."));
        await _documentManagerRepository.CreateFolderAsync();
    }

    async public Task FindFolderAsync()
    {
        await Task.Run(() => Console.WriteLine("Findind folder..."));
        await _documentManagerRepository.FindFolderAsync();
    }

    async public Task SendJobToFolderAsync()
    {
        await Task.Run(() => Console.WriteLine("Sending job entry to folder..."));
        await _documentManagerRepository.SendJobToFolderAsync();
    }
}