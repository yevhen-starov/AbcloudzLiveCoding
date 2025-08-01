var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Abcloudz.WebAPI.Services.IUserService>(sp =>
    new Abcloudz.WebAPI.Services.UserService(sp.GetRequiredService<IConfiguration>()));
builder.Services.AddSingleton<Abcloudz.WebAPI.Services.IFileService, Abcloudz.WebAPI.Services.FileService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<Abcloudz.WebAPI.Middlewares.ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
