
namespace JobBank.Jobs.Apply.Domain;
public class DocumentManagerService : IDocumentManagerService
{
    async public Task CreateFolderAsync()
    {
        await Task.Run(() => Console.WriteLine("Creating folder..."));
    }

    async public Task FindFolderAsync()
    {
        await Task.Run(() => Console.WriteLine("Findind folder..."));
    }

    async public Task SendAsync()
    {
        await Task.Run(() => Console.WriteLine("Creating job entry..."));
    }

    async public Task SendJobToFolderAsync()
    {
        await Task.Run(() => Console.WriteLine("Sending job entry to folder..."));
    }
}