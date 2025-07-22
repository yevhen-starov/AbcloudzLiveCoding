using Abcloudz.Core.Interfaces;
using Abcloudz.Core.Services;
using Abcloudz.Core.Services.FileStorages;
using Abcloudz.DAL;
using Abcloudz.DAL.Interfaces;
using Abcloudz.DAL.Repositories;
using Abcloudz.WebAPI.Filters;
using Microsoft.EntityFrameworkCore;

namespace Abcloudz.WebAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureInfrastructure(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("TestDb"));

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly));
        }

        public void ConfigureCore(IServiceCollection services)
        {
            services.AddScoped<ExceptionFilter>();
            services.AddScoped<IUserRepository, UserRepository>();

            var useAzureStorage = _configuration.GetValue<bool>("StorageSettings:UseAzureStorage");
            if (useAzureStorage)
            {
                services.AddSingleton<IStorageProvider, AzureBlobStorageProvider>();
            }
            else
            {
                services.AddSingleton<IStorageProvider, FileSystemStorageProvider>();
            }

            services.AddScoped<IStorageManager, StorageManager>();
            services.AddScoped<IUserDocumentService, UserDocumentService>();
            services.AddScoped<IUserDocumentsRepository, UserDocumentsRepository>();
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
