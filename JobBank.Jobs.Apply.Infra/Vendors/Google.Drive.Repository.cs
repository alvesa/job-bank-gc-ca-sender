using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Docs.v1;
using Google.Apis.Docs.v1.Data;
using Google.Apis.Services;
using JobBank.Jobs.Apply.Domain.Vendors;
using static Google.Apis.Docs.v1.DocumentsResource;

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

            var service = new DocsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = this.clientService.ApplicationName
            });

            var documentId = "[documentId]";

            GetRequest request = service.Documents.Get(documentId);

            var doc = request.Execute();

            var items = doc.Body.Content;

            var newRequests = new List<Request>();

            foreach (var item in items)
            {
                if (item.Paragraph != null)
                {
                    foreach (var content in item.Paragraph.Elements)
                    {
                        content.TextRun.Content = content.TextRun.Content.Replace("[MONTH]", "October");
                        newRequests.Add(new Request
                        {
                            InsertText = new InsertTextRequest
                            {
                                Text = content.TextRun.Content.Replace("[MONTH]", "October"),
                                ETag = content.ETag,
                                Location = new Location
                                {
                                    Index = content.StartIndex
                                }
                            }
                        });
                    }
                }
            }

            CreateRequest rq = service.Documents.Create(new Google.Apis.Docs.v1.Data.Document
            {
                Body = new Body
                {
                    Content = doc.Body.Content
                },
                Title = "new_file",
            });

            var newDoc = rq.Execute();

            BatchUpdateRequest updateRequest = service.Documents.BatchUpdate(
                new BatchUpdateDocumentRequest
                {
                    Requests = newRequests
                },
                newDoc.DocumentId
            );

            updateRequest.Execute();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}