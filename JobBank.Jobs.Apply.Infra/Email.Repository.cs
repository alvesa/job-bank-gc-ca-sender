
namespace JobBank.Jobs.Apply.Infra;

public class EmailRepository : IEmailRespository
{
    public async Task SendEmailAsync()
    {
        await Task.Run(() => Console.WriteLine("Sending email..."));
    }
}