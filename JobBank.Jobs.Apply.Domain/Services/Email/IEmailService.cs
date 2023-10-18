namespace JobBank.Jobs.Apply.Domain;

public interface IEmailService
{
    void PrepareBody(string jobOffer);
    void PrepareSubject(string jobOffer, string jobId);
    Task SendEmailAsync(string to);
}