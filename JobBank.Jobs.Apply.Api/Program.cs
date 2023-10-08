using JobBank.Jobs.Apply.Domain;
using JobBank.Jobs.Apply.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IJobBankSenderService, JobBankSenderService>();
builder.Services.AddScoped<ICoverLetterService, CoverLetterService>();
builder.Services.AddScoped<IDocumentManagerService, DocumentManagerService>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddScoped<IDocumentManagerRepository, DocumentManagerRepository>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
