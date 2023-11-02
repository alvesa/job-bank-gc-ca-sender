

using JobBank.Jobs.Apply.Domain.Models;

namespace JobBank.Jobs.Apply.Domain;

public class JobBankSenderService : IJobBankSenderService
{
    private readonly ICoverLetterService _coverLetterService;
    public int MyProperty { get; set; }

    public JobBankSenderService(ICoverLetterService coverLetterService)
    {
        _coverLetterService = coverLetterService;
    }

    public async Task<bool> SendAsync(JobSenderDTO request)
    {
        try
        {
            return await Send(request);
        }
        catch (Exception)
        {
            return false;
        }
    }

    private async Task<bool> Send(JobSenderDTO request)
    {
        try
        {
            // Step 1: Updating the cover letter statements
            return await CoverLetterBuilder(request.Job);
            // Step 2: Structuring the email contents
            // Step 3: Documenting the application sent
            // Step 4: Sending the email
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private async Task<bool> CoverLetterBuilder(JobDTO jobOptions)
    {
        try
        {
            await _coverLetterService.CreateCoverLeter(jobOptions);
            await _coverLetterService.GetCoverLetter();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }
}