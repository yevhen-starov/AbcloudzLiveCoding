using Abcloudz.WebAPI;
using Abcloudz.WebAPI.Configuration;
using Abcloudz.WebAPI.Filters;
using Abcloudz.WebAPI.Validations.Users;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureInfrastructure(builder.Services);

startup.ConfigureCore(builder.Services);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilter>();
}).AddFluentValidation(fv =>
        fv.RegisterValidatorsFromAssemblyContaining<CreateUserRequestValidator>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<StorageSettings>(builder.Configuration.GetSection("StorageSettings"));

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();
