using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Docs.v1;
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
            var clientSecrets = await GoogleClientSecrets.FromFileAsync("./g-docs-credentials.json");

            var scopes = new string[] { DocsService.ScopeConstants.DriveFile, DocsService.ScopeConstants.Documents, DocsService.ScopeConstants.DriveFile };

            var initializer = new GoogleAuthorizationCodeFlow.Initializer
            {
                Scopes = scopes,
                ClientSecrets = clientSecrets.Secrets
            };

            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                initializer,
                scopes,
                "user",
                CancellationToken.None);

            Console.WriteLine(credential);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}