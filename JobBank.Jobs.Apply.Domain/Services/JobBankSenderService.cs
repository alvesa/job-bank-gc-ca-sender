

using JobBank.Jobs.Apply.Api.Controllers;

namespace JobBank.Jobs.Apply.Domain;

public class JobBankSenderService : IJobBankSenderService
{
    private readonly ICoverLetterService _coverLetterService;
    private readonly IEmailService _emailService;
    private readonly IDocumentManagerService _documentManagerService;

    public JobBankSenderService(ICoverLetterService coverLetterService, IEmailService emailService, IDocumentManagerService documentManagerService)
    {
        _coverLetterService = coverLetterService;
        _emailService = emailService;
        _documentManagerService = documentManagerService;
    }

     public async Task<bool> SendAsync(JobSenderRequest request)
    {
        try
        {
            await this.Send();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private async Task Send() {

        await this.EmailBuilder();
        await this.CoverLetterBuilder();
        await this.DocumentBuilder();
        await _emailService.SendEmailAsync();
    }

    private async Task DocumentBuilder() {
        await this._documentManagerService.FindFolderAsync();
        await this._documentManagerService.CreateFolderAsync();
        await this._documentManagerService.CreateFolderAsync();
        await this._documentManagerService.SendJobToFolderAsync();
    }

    private async Task EmailBuilder() {
        await _emailService.PrepareSubject();
        await _emailService.PrepareBody();
    }

    private async Task CoverLetterBuilder() {
        await _coverLetterService.CreateCoverLeter();
        await _coverLetterService.GetCoverLetter();
    }
}