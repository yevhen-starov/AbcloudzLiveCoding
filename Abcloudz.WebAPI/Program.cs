using Abcloudz.WebAPI.DTOs;
using Abcloudz.WebAPI.Infrastructure.Middlewares;
using Abcloudz.WebAPI.Interfaces;
using Abcloudz.WebAPI.Models;
using Abcloudz.WebAPI.Services;
using Abcloudz.WebAPI.Validation;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddScoped<IUserRepository, InMemoryUserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Validators
builder.Services.AddScoped<IValidator<CreateUserModel>, UserViewModelValidator>();
builder.Services.AddScoped<IValidator<UserDTO>, UserDTOValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middlewares
app.UseMiddleware<ExceptionHandlerMiddleware>(); // First always

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
