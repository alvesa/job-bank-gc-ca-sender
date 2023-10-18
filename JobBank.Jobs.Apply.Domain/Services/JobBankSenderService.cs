

using JobBank.Jobs.Apply.Domain.Models;

namespace JobBank.Jobs.Apply.Domain;

public class JobBankSenderService : IJobBankSenderService
{
    private readonly ICoverLetterService _coverLetterService;
    private readonly IEmailService _emailService;
    private readonly IDocumentManagerService _documentManagerService;

    public int MyProperty { get; set; }

    public JobBankSenderService(ICoverLetterService coverLetterService, IEmailService emailService, IDocumentManagerService documentManagerService)
    {
        _coverLetterService = coverLetterService;
        _emailService = emailService;
        _documentManagerService = documentManagerService;
    }

    public async Task<bool> SendAsync(JobSenderDTO request)
    {
        try
        {
            await Send(request);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private async Task Send(JobSenderDTO request)
    {
        // Step 1: Structuring the email contents
        EmailBuilder(request.Job);
        // Step 2: Updating the cover letter statements
        await CoverLetterBuilder(request.Job);
        // Step 3: Documenting the application sent
        await DocumentBuilder(request.Job);
        // Step 4: Sending the email
        await _emailService.SendEmailAsync(request.Email.To);
    }

    private async Task DocumentBuilder(JobDTO jobOptions)
    {
        await _documentManagerService.FindFolderAsync();
        await _documentManagerService.CreateFolderAsync();
        await _documentManagerService.SendJobToFolderAsync();
    }

    private void EmailBuilder(JobDTO jobOptions)
    {
        _emailService.PrepareSubject(jobOptions.Offer, jobOptions.Number);
        _emailService.PrepareBody(jobOptions.Offer);
    }

    private async Task CoverLetterBuilder(JobDTO jobOptions)
    {
        await _coverLetterService.CreateCoverLeter(jobOptions);
        await _coverLetterService.GetCoverLetter();
    }
}