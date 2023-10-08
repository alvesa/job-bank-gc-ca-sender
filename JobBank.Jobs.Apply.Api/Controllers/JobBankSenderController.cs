using JobBank.Jobs.Apply.Domain;
using Microsoft.AspNetCore.Mvc;

namespace JobBank.Jobs.Apply.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class JobBankSenderController : ControllerBase
{
    private readonly ILogger<JobBankSenderController> _logger;
    private readonly IJobBankSenderService _jobBankSenderService;

    public JobBankSenderController(ILogger<JobBankSenderController> logger, IJobBankSenderService jobBankSenderService)
    {
        _logger = logger;
        _jobBankSenderService = jobBankSenderService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] JobSenderRequest request)
    {
        _logger.Log(LogLevel.Information, "Initializing JobBankSender");
        var response = await _jobBankSenderService.SendAsync(request);
        return Created("Email sent successfuly", response);
    }
}



