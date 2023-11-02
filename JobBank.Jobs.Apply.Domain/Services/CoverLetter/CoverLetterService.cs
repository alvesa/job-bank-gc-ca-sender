

using JobBank.Jobs.Apply.Domain.Models;

namespace JobBank.Jobs.Apply.Domain;

public class CoverLetterService : ICoverLetterService
{
    private readonly IDocumentManagerRepository _documentManagerRepository;

    public CoverLetterService(IDocumentManagerRepository documentManagerRepository)
    {
        _documentManagerRepository = documentManagerRepository;
    }

    public async Task CreateCoverLeter(JobDTO jobOptions)
    {
        await _documentManagerRepository.CreateCoverLetterAsync();
    }

    async public Task GetCoverLetter()
    {
        await Task.Run(() => Console.WriteLine("Getting coverLetter..."));
        await _documentManagerRepository.GetCoverLetterAsync();
    }
}