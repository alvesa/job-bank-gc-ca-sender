using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using JobBank.Jobs.Apply.Domain.Vendors;

namespace JobBank.Jobs.Apply.Infra.Vendors;
public class GoogleDriveRepository : IGoogleDriveRepository
{
    private readonly IClientService clientService;

    public GoogleDriveRepository(IClientService clientService)
    {
        this.clientService = clientService;
    }

    public void ChangeFile(string newContent)
    {
        throw new NotImplementedException();
    }

    public void CreateFile(string content)
    {
        throw new NotImplementedException();
    }

    public async Task ListFiles()
    {
        try
        {
            var clientSecrets = await GoogleClientSecrets.FromFileAsync("./g-drive-credentials.json");

            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                clientSecrets.Secrets,
                new[] { DriveService.ScopeConstants.DriveFile },
                "user",
                CancellationToken.None);

            var service = new DriveService.Initializer()
            {
                HttpClientInitializer = credential
            };
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}