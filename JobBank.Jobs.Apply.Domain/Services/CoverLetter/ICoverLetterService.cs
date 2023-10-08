

namespace JobBank.Jobs.Apply.Domain;

public interface ICoverLetterService
{
    Task CreateCoverLeter();
    Task GetCoverLetter();
}