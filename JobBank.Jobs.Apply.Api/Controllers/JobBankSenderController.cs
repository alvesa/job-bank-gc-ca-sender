using Microsoft.AspNetCore.Mvc;

namespace JobBank.Jobs.Apply.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class JobBankSenderController : ControllerBase
{
    private readonly ILogger<JobBankSenderController> _logger;

    public JobBankSenderController(ILogger<JobBankSenderController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult Post([FromBody] JobSenderRequest request)
    {
        _logger.Log(LogLevel.Information, "Initializing JobBankSender");
        return Created("", request);
    }
}



