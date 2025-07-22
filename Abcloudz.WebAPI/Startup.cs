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
