using JobBank.Jobs.Apply.Domain.Models;

namespace JobBank.Jobs.Apply.Domain;
public interface IJobBankSenderService {
    Task<bool> SendAsync(JobSenderDTO request);
}