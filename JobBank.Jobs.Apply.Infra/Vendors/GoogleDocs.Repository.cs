using Google.Apis.Docs.v1;
using Google.Apis.Requests;
using JobBank.Jobs.Apply.Domain.Vendors;

namespace JobBank.Jobs.Apply.Infra.Vendors;
public class GoogleDocsRepository : DocsService, IGoogleDocsRepository
{
    public async Task ChangeFile(string newContent)
    {
        System.Console.WriteLine(newContent);
    }

    async public Task CreateFile()
    {
        
        // try
        // {
        //     var clientSecrets = await GoogleClientSecrets.FromFileAsync("./g-docs-credentials.json");

        //     var scopes = new string[] { DocsService.ScopeConstants.DriveFile, DocsService.ScopeConstants.Documents, DocsService.ScopeConstants.DriveFile };

        //     var initializer = new GoogleAuthorizationCodeFlow.Initializer
        //     {
        //         Scopes = scopes,
        //         ClientSecrets = clientSecrets.Secrets
        //     };

        //     var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
        //         initializer,
        //         scopes,
        //         "user",
        //         CancellationToken.None);

        //     var service = new DocsService(new BaseClientService.Initializer
        //     {
        //         HttpClientInitializer = credential,
        //         ApplicationName = this.clientService.ApplicationName
        //     });

        

        //     GetRequest request = service.Documents.Get(documentId);

        //     var doc = request.Execute();

        //     var items = doc.Body.Content;

        //     var newRequests = new List<Request>();

        //     foreach (var item in items)
        //     {
        //         if (item.Paragraph != null)
        //         {
        //             foreach (var content in item.Paragraph.Elements)
        //             {
        //                 content.TextRun.Content = content.TextRun.Content.Replace("[MONTH]", "October");
        //                 newRequests.Add(new Request
        //                 {
        //                     InsertText = new InsertTextRequest
        //                     {
        //                         Text = content.TextRun.Content.Replace("[MONTH]", "October"),
        //                         ETag = content.ETag,
        //                         Location = new Location
        //                         {
        //                             Index = content.StartIndex
        //                         }
        //                     }
        //                 });
        //             }
        //         }
        //     }

        //     CreateRequest rq = service.Documents.Create(new Document
        //     {
        //         Body = new Body
        //         {
        //             Content = doc.Body.Content
        //         },
        //         Title = "new_file",
        //     });

        //     var newDoc = rq.Execute();

        //     BatchUpdateRequest updateRequest = service.Documents.BatchUpdate(
        //         new BatchUpdateDocumentRequest
        //         {
        //             Requests = newRequests
        //         },
        //         newDoc.DocumentId
        //     );

        //     updateRequest.Execute();
        // }
        // catch (Exception ex)
        // {
        //     throw ex;
        // }
    }
}