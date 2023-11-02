public interface IDocumentManagerRepository {
    Task CreateCoverLetterAsync();
    Task GetCoverLetterAsync();
}