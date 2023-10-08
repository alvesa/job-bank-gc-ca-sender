namespace JobBank.Jobs.Apply.Api.Controllers;

public class JobSenderRequest {
    public required EmailOptions EmailOptions { get; set; }
    public required JobBankOptions JobBankOptions { get; set; }
}

public class EmailOptions {
    public required string To { get; set; }
    public required string Subject { get; set; }
    public string? Body { get; set; }
}

public class JobBankOptions {
    public required string JobId { get; set; }
    public required string JobOfferName { get; set; }
    public string? CompanyName { get; set; }
}