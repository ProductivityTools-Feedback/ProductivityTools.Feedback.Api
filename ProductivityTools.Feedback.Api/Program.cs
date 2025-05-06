using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using ProductivityTools.EchoApi;
using ProductivityTools.Feedback.Database;
using ProductivityTools.MasterConfiguration;
using System;

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddMasterConfiguration(configName: "ProductivityTools.Feedback.Api.json", force: true)
              .Build();

string masterconfpath = Environment.GetEnvironmentVariable("MasterConfigurationPath");
FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile($"{masterconfpath}\\ProductivityTools.Feedback.Cmdlet.Prod.ServiceAccount.json"),
});

//// Add services to the container.


IdentityModelEventSource.ShowPII = true;
builder.Services
 .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.Authority = "https://securetoken.google.com/ptfeedbackprod";
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidIssuer = "https://securetoken.google.com/ptfeedbackprod",
         ValidateAudience = true,
         ValidAudience = "ptfeedbackprod",
         ValidateLifetime = true
     };
 });
builder.Services.AddScoped<TeamManagmentContext>();
builder.Services.AddControllers().AddApplicationPart(typeof(EchoController).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
    builder =>
    {
        builder.WithOrigins("https://ptservicestatus-309299231472.us-central1.run.app/").AllowAnyMethod().AllowAnyHeader();
    });
}); //validate jenksinfile



var app = builder.Build();
app.UseRouting();//not sure if required
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
