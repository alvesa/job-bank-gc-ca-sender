

namespace JobBank.Jobs.Apply.Domain;

public class CoverLetterService : ICoverLetterService
{
    public async Task CreateCoverLeter()
    {
        await Task.Run(() => Console.WriteLine("Creating coverLetter..."));
    }

    async public Task GetCoverLetter()
    {
        await Task.Run(() => Console.WriteLine("Getting coverLetter..."));
    }
}