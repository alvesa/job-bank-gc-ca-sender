namespace JobBank.Jobs.Apply.Domain.Models;

public class JobSenderDTO {
    public required EmailDTO Email { get; set; }
    public required JobDTO Job { get; set; }
    public required MetaOptionsDTO Meta { get; set; }
}

public class EmailDTO {
    public required string To { get; set; }
}

public class JobDTO {
    public required string Number { get; set; }
    public required string Offer { get; set; }
    public required string Link { get; set; }
    public string? CompanyName { get; set; }
}

public class MetaOptionsDTO {
    public DateTime Date { get; set; }
}