using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment;
var environment = env.EnvironmentName;
var configuration = builder.Configuration;
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true);

builder.Services.AddInfrastructure(builder.Configuration);
var app = builder.Build();
app.UseInfrastructure(env);
app.MapControllers();
app.Run();

