public interface IDocumentManagerRepository {
    Task CreateFolderAsync();
    Task FindFolderAsync();
    Task SendJobToFolderAsync();
    Task CreateCoverLetterAsync();
    Task GetCoverLetterAsync();
    Task GetCurriculum();
}