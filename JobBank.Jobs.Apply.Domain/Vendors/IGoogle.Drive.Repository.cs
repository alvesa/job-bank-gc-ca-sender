namespace JobBank.Jobs.Apply.Domain.Vendors;
public interface IGoogleDriveRepository {
    void CreateFile(string content);
    void ChangeFile(string newContent);
    Task ListFiles();
}