using Google.Apis.Docs.v1;
using Google.Apis.Services;
using JobBank.Jobs.Apply.Api.Helper;
using JobBank.Jobs.Apply.Domain;
using JobBank.Jobs.Apply.Domain.Vendors;
using JobBank.Jobs.Apply.Infra;
using JobBank.Jobs.Apply.Infra.Vendors;

var builder = WebApplication.CreateBuilder(args);

IConfigurationBuilder configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddScoped<IJobBankSenderService, JobBankSenderService>();
builder.Services.AddScoped<ICoverLetterService, CoverLetterService>();

builder.Services.AddScoped<IDocumentManagerRepository, DocumentManagerRepository>();

builder.Services.AddScoped<DocsService, GoogleDocsRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

await Task.Run(builder.AddDocumentService);

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
