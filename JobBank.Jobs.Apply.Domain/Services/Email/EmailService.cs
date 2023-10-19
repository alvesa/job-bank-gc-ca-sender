namespace JobBank.Jobs.Apply.Domain;

public class EmailService : IEmailService
{
    private readonly IEmailRepository _emailRepository;

    public string To { get; private set; }
    public string Subject { get; private set; }
    public string HtmlBody { get; private set; }

    public EmailService(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }

    void IEmailService.PrepareBody(string jobOffer)
    {
        this.HtmlBody = $"I've found in jobbank.gc.ca website for a {jobOffer} position and I would like to apply for it.";
    }

    void IEmailService.PrepareSubject(string jobOffer, string jobId)
    {
        this.Subject = $"Job Bank Canada {jobId} - {jobOffer}";

        Console.WriteLine(this.Subject);
    }

    async Task IEmailService.SendEmailAsync(string To)
    {
        this.To = To;
        var sendMail = $"Sending email to {this.To} with {this.Subject} and {this.HtmlBody} body...";

        Console.WriteLine(sendMail);

        await _emailRepository.SendEmailAsync();
    }
}