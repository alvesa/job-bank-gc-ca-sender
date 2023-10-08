namespace JobBank.Jobs.Apply.Domain;

public interface IEmailService
{
    Task PrepareBody();
    Task PrepareSubject();
    Task SendEmailAsync();
}