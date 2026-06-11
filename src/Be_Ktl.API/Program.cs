using Be_Ktl.Infrastructure;

// Load environment variables from .env file
LoadEnvironmentVariables();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void LoadEnvironmentVariables()
{
    var envFile = Path.Combine(
        Directory.GetCurrentDirectory(),
        "..",
        "..",
        ".env");

    if (!File.Exists(envFile))
        return;

    foreach (var line in File.ReadAllLines(envFile))
    {
        if (string.IsNullOrWhiteSpace(line))
            continue;

        if (line.StartsWith("#"))
            continue;

        var index = line.IndexOf('=');

        if (index <= 0)
            continue;

        var key = line[..index].Trim();
        var value = line[(index + 1)..].Trim();

        Environment.SetEnvironmentVariable(key, value);
    }
}