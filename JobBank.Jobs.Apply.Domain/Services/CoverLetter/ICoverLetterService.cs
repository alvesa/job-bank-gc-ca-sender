

using JobBank.Jobs.Apply.Domain.Models;

namespace JobBank.Jobs.Apply.Domain;

public interface ICoverLetterService
{
    Task CreateCoverLeter(JobDTO jobOptions);
    Task GetCoverLetter();
}