
using Enterprise.Applications.Application;
using Enterprise.Applications.Identity.API.Configuration;
using Enterprise.Applications.Infra;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

configuration
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($@"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
        .AddCommandLine(args)
        .AddEnvironmentVariables()
        .AddUserSecrets(typeof(Program).Assembly).Build();

builder.Services.AddIdentityConfiguration(configuration);
builder.Services.AddApiConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
var environment = app.Environment;

app.UseSwaggerConfiguration();
app.UseApiConfiguration(environment);

app.Run();
