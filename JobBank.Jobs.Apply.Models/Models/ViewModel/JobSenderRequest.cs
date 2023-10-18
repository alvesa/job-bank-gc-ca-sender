namespace JobBank.Jobs.Apply.Api.Controllers;

public class JobSenderRequest {
    public required Email Email { get; set; }
    public required Job Job { get; set; }
    public required MetaOptions Meta { get; set; }
}

public class Email {
    public required string To { get; set; }
}

public class Job {
    public required string Number { get; set; }
    public required string Offer { get; set; }
    public required string Link { get; set; }
    public string? CompanyName { get; set; }
}

public class MetaOptions {
    public DateTime Date { get; set; }
}