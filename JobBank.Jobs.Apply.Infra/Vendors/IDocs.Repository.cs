using Google.Apis.Services;

namespace JobBank.Jobs.Apply.Domain.Vendors;
public interface IDocsRepository {
    Task CreateFile();
    Task ChangeFile(string newContent);
    Task ListFiles();
}