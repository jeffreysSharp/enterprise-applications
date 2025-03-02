
using Enterprise.Applications.Application;
using Enterprise.Applications.Application.Common.Interfaces;
using Enterprise.Applications.Identity.Infra.Services;
using Enterprise.Applications.Infra;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

configuration
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($@"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
        .AddCommandLine(args)
        .AddEnvironmentVariables()
        .AddUserSecrets(typeof(Program).Assembly).Build();

builder.Services.AddControllers();

// For authentication
var _key = builder.Configuration["Jwt:Key"];
var _issuer = builder.Configuration["Jwt:Issuer"];
var _audience = builder.Configuration["Jwt:Audience"];
var _expirtyMinutes = builder.Configuration["Jwt:ExpiryMinutes"];

// Configuration for token
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(bearerOptions =>
{
    bearerOptions.RequireHttpsMetadata = true;
    bearerOptions.SaveToken = true;
    bearerOptions.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,        
        ValidAudience = _audience,
        ValidIssuer = _issuer,        
        ClockSkew = TimeSpan.FromMinutes(Convert.ToDouble(_expirtyMinutes))
    };
});


// Dependency injection with key
builder.Services.AddSingleton<ITokenGenerator>(new TokenGenerator(
    _key, _issuer, _audience, _expirtyMinutes));


// Include Application Dependency
builder.Services.AddApplicationServices();

// Include Infrastructur Dependency
builder.Services.AddInfrastructure(builder.Configuration);


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder
            .WithOrigins("https://localhost:7219")
            .AllowAnyMethod()
            .AllowAnyHeader() // Allow any header
            .AllowCredentials();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Enterprise Applications Identity API",
        Description = "This API is responsible for user management in the Enterprise Applications project.",
        Contact = new OpenApiContact() { Name = "Jeferson Almeida", Email = "jeffreys.sharp@outlook.com" },
        License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/license/mit") }
    })
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();


app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
