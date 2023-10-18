

using JobBank.Jobs.Apply.Api.Controllers;

namespace JobBank.Jobs.Apply.Domain;

public class CoverLetterService : ICoverLetterService
{
    private readonly IDocumentManagerRepository _documentManagerRepository;

    public CoverLetterService(IDocumentManagerRepository documentManagerRepository)
    {
        _documentManagerRepository = documentManagerRepository;
    }

    public async Task CreateCoverLeter(Job jobOptions)
    {
        await Task.Run(() => Console.WriteLine($"Creating coverLetter... {jobOptions.CompanyName} - {jobOptions.JobOffer}"));
        await _documentManagerRepository.CreateCoverLetterAsync();
    }

    async public Task GetCoverLetter()
    {
        await Task.Run(() => Console.WriteLine("Getting coverLetter..."));
        await _documentManagerRepository.GetCoverLetterAsync();
    }
}