
using JobBank.Jobs.Apply.Domain.Vendors;

namespace JobBank.Jobs.Apply.Infra;

public class DocumentManagerRepository : IDocumentManagerRepository
{
    private readonly IGoogleDocsRepository googleDriveRepository;

    public DocumentManagerRepository(IGoogleDocsRepository googleDriveRepository)
    {
        this.googleDriveRepository = googleDriveRepository;
    }

    public async Task CreateCoverLetterAsync()
    {
        await this.googleDriveRepository.CreateFile();
    }

    public async Task GetCoverLetterAsync()
    {
        await this.googleDriveRepository.ListFiles();
    }
}