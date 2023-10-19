namespace JobBank.Jobs.Apply.Domain.Configs;

public class JobBankConfiguration {

    public static string ConfigureName = "Cloud-Storage";

    public required string ClientId { get; set; }
    public required string ClientSecret { get; set; }
    public required string ApplicationName { get; set; }
    public required string ApiKey { get; set; }
}