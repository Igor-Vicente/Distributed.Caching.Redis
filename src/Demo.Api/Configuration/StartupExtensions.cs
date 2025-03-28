using Demo.Api.Data;
using Demo.Api.Data.Repository;
using Demo.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api.Configuration
{
    public static class StartupExtensions
    {
        public static void AddDistributedRedisCaching(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
                options.InstanceName = "Demo.Api";
            });
        }
        public static void AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DemoDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("Sqlserver")));
        }

        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddSingleton<ICacheService, CacheService>();
        }

    }
}
