namespace JobBank.Jobs.Apply.Domain;

public class EmailService : IEmailService
{
    private readonly IEmailRespository _emailRespository;

    public EmailService(IEmailRespository emailRespository)
    {
        _emailRespository = emailRespository;
    }

    async Task IEmailService.PrepareBody()
    {
        await Task.Run(() => Console.WriteLine("Preparing body..."));
    }

    async Task IEmailService.PrepareSubject()
    {
        await Task.Run(() => Console.WriteLine("Preparing subject..."));
    }

    async Task IEmailService.SendEmailAsync()
    {
        await Task.Run(() => Console.WriteLine("Sending email..."));
        await _emailRespository.SendEmailAsync();
    }
}