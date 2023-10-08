using JobBank.Jobs.Apply.Api.Controllers;

namespace JobBank.Jobs.Apply.Domain;
public interface IJobBankSenderService {
    Task<bool> SendAsync(JobSenderRequest request);
}