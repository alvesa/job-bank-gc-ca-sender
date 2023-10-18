

using JobBank.Jobs.Apply.Api.Controllers;

namespace JobBank.Jobs.Apply.Domain;

public interface ICoverLetterService
{
    Task CreateCoverLeter(Job jobOptions);
    Task GetCoverLetter();
}