using Abcloudz.Application;
using Abcloudz.Application.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Abcloudz.Database;

public static class DI
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services
            .AddScoped<IRepository<User>, UserRepository>()
            .AddSingleton(typeof(IDataStorage<>), typeof(FileStorage<>));
        return services;
    }
}