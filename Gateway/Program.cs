using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile($"configuration.{builder.Environment.EnvironmentName.ToString().ToLower()}.json");

builder.Services.AddAuthentication().AddJwtBearer("GatewayAuthenticationScheme", options =>
{
    options.Authority = builder.Configuration["IdentityServerUrl"];
    options.Audience = "resource_gateway";
    options.RequireHttpsMetadata = false;
});
builder.Services.AddOcelot();
var app = builder.Build();


await app.UseOcelot();

app.Run();
