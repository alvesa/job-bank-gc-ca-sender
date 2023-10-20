using Google.Apis.Docs.v1;
using Google.Apis.Services;
using JobBank.Jobs.Apply.Domain;
using JobBank.Jobs.Apply.Domain.Configs;
using JobBank.Jobs.Apply.Domain.Vendors;
using JobBank.Jobs.Apply.Infra;
using JobBank.Jobs.Apply.Infra.Vendors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IJobBankSenderService, JobBankSenderService>();
builder.Services.AddScoped<ICoverLetterService, CoverLetterService>();
builder.Services.AddScoped<IDocumentManagerService, DocumentManagerService>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddScoped<IDocumentManagerRepository, DocumentManagerRepository>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();

builder.Services.AddScoped<IGoogleDriveRepository, GoogleDriveRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration =
    new ConfigurationBuilder()
        .AddConfiguration(builder.Configuration.GetSection(JobBankConfiguration.ConfigureName)).Build();

builder.Services.AddSingleton<IClientService>(new DocsService(new BaseClientService.Initializer
{
    ApiKey = configuration["ApiKey"],
    ApplicationName = configuration["ApplicationName"],
    // HttpClientInitializer =
    //     GoogleWebAuthorizationBroker.AuthorizeAsync(
    //         GoogleClientSecrets.FromFileAsync("./g-drive-credentials.json").Result.Secrets,
    //         new[] { DriveService.ScopeConstants.DriveFile },
    //         "user",
    //         CancellationToken.None).Result

}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
