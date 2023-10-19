
using JobBank.Jobs.Apply.Domain.Vendors;

namespace JobBank.Jobs.Apply.Infra;

public class DocumentManagerRepository : IDocumentManagerRepository
{
    private readonly IGoogleDriveRepository googleDriveRepository;

    public DocumentManagerRepository(IGoogleDriveRepository googleDriveRepository)
    {
        this.googleDriveRepository = googleDriveRepository;
    }

    public async Task CreateCoverLetterAsync()
    {
        await Task.Run(() => Console.WriteLine("Creating cover letter repository..."));
    }

    public async Task CreateFolderAsync()
    {
        await Task.Run(() => Console.WriteLine("Creating folder repository..."));
    }

    public async Task FindFolderAsync()
    {
        await Task.Run(() => Console.WriteLine("Finding folder repository..."));
    }

    public async Task GetCoverLetterAsync()
    {
        await this.googleDriveRepository.ListFiles();
    }

    public async Task GetCurriculum()
    {
        await Task.Run(() => Console.WriteLine("Getting curriculum..."));
    }

    public async Task SendJobToFolderAsync()
    {
        await Task.Run(() => Console.WriteLine("Sending document to folder repository..."));
    }
}