using JobBank.Jobs.Apply.Domain;
using JobBank.Jobs.Apply.Domain.Models;
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

        // TODO: Implement automapper
        var item = new JobSenderDTO
        {
            Email = new EmailDTO
            {
                To = request.Email.To
            },
            Job = new JobDTO
            {
                Link = request.Job.Link,
                Offer = request.Job.Offer,
                Number = request.Job.Number,
                CompanyName = request.Job.CompanyName,
            },
            Meta = new MetaOptionsDTO
            {
                Date = request.Meta.Date
            }
        };

        var response = await _jobBankSenderService.SendAsync(item);

        return Created("Email sent successfuly", response);
    }

    [HttpGet("/google-redirect-response")]
    public async Task<IActionResult> GetGoogleRedirectAsync() {
        return Ok();
    }
}



