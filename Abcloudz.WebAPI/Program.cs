using Abcloudz.WebAPI;
using Abcloudz.WebAPI.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services
    .AddScoped<UserRepository>()
    .AddSingleton(typeof(IDataStorage<>), typeof(FileStorage<>));

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
