namespace JobBank.Jobs.Apply.Domain.Vendors;
public interface IGoogleDocsRepository {
    Task CreateFile();
    Task ChangeFile(string newContent);
}