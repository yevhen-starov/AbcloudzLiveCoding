using Abcloudz.Database;
using Abcloudz.Database.Settings;
using Abcloudz.WebAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.Sources.Clear();
builder.Configuration
    .AddJsonFile("appsettings.json", false, true);

builder.Services.AddControllers();
builder.Services
    .AddDatabase()
    .Configure<StorageSettings>(builder.Configuration.GetSection(nameof(StorageSettings)));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
    
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<AbcloudzExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
