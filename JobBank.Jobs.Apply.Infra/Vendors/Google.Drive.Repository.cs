using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using JobBank.Jobs.Apply.Domain.Vendors;
using Newtonsoft.Json;

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
            var test = this.clientService.ApiKey;
            var clientId = "[CLIENT_ID]";
            var clientSecret = "[CLIENT_SECRET]";

            string[] Scopes = { DriveService.Scope.DriveReadonly };

            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                },
                Scopes,
                "user",
                CancellationToken.None
            // new FileDataStore("Google.Apis.Auth", true)
            );

            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "[APP_NAME]"
            });
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }
}