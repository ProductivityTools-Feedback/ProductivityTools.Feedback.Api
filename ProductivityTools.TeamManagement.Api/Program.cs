using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.IdentityModel.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Builder;
using ProductivityTools.MasterConfiguration;

using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductivityTools.TeamManagement.Database;
using ProductivityTools.EchoApi;

string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddMasterConfiguration(configName: "ProductivityTools.TeamManagement.Api.json", force: true)
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
     options.Authority = "https://securetoken.google.com/pttransfersprod";
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidIssuer = "https://securetoken.google.com/pttransfersprod",
         ValidateAudience = true,
         ValidAudience = "pttransfersprod",
         ValidateLifetime = true
     };
 });
builder.Services.AddScoped<TeamManagmentContext>();
builder.Services.AddControllers().AddApplicationPart(typeof(EchoController).Assembly);

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(MyAllowSpecificOrigins,
//    builder =>
//    {
//        builder.WithOrigins("http://localhost:3000", "https://localhost:3000", "https://transfersweb.z16.web.core.windows.net").AllowAnyMethod().AllowAnyHeader();
//    });
//});



var app = builder.Build();
app.UseRouting();//not sure if required
//app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
