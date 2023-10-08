namespace JobBank.Jobs.Apply.Domain;
public interface IJobBankSenderService {
    Task SendAsync();
}