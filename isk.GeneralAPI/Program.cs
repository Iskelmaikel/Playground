using isk.GeneralAPI;
using isk.GeneralAPI.Benchmarks;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureMyAppSettings(); // Custom extension method to configure and load appsettings
var settings = builder.Configuration.GetRequiredSection("Settings").Get<Settings>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks(); // Adds a healthcheck service & endpoint to the application

var app = builder.Build();
app.MapHealthChecks("health"); // Maps the healthcheck endpoint to the given URI

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if(settings.IsBenchmarkRun.HasValue == true &&  settings.IsBenchmarkRun.Value == true)
{
    /// To enable benchmarks, build the application in release mode, navigate to the output dir ({...}\bin\Release\net6.0)
    /// and run the dotnet 'target dll' command. e.g.: "dotnet isk.GeneralAPI.dll\isk.GeneralAPI.dll" in any supported CLI
    BenchmarkExecute.ExecuteMyBenchmarks(); // Uses BenchmarkDotNet to execute one or more benchmarks specified.
}
else
{
    app.Run();
}

