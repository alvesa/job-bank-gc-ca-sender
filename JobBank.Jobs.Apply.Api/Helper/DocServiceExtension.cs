using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Docs.v1;
using Google.Apis.Requests;
using Google.Apis.Services;

namespace JobBank.Jobs.Apply.Api.Helper;

public static class DocServiceExtension
{
    public static void AddDocumentService(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IClientService, DocsService>(scoped =>
        {
            var clientSecrets = GoogleClientSecrets.FromFileAsync("./g-docs-credentials.json").Result;

            var scopes = new string[] { DocsService.ScopeConstants.DriveFile, DocsService.ScopeConstants.Documents, DocsService.ScopeConstants.DriveFile };

            var initializer = new GoogleAuthorizationCodeFlow.Initializer
            {
                Scopes = scopes,
                ClientSecrets = clientSecrets.Secrets
            };

            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                initializer,
                scopes,
                "user",
                CancellationToken.None).Result;

            var service = new DocsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                // ApplicationName = this.clientService.ApplicationName
            });

            return service;
        });
    }

}