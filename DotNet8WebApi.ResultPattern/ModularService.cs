using DotNet8WebApi.ResultPattern.Database;
using DotNet8WebApi.ResultPattern.Features.Blog;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebApi.ResultPattern
{
    public static class ModularService
    {
        public static IServiceCollection AddFeatures(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContextService(builder);
            services.AddJsonService();
            services.AddDataAccessServices();
            services.AddBusinessLogicServices();

            return services;
        }

        private static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<DA_Blog>();
            return services;
        }

        private static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<BL_Blog>();
            return services;
        }

        private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            });

            return services;
        }

        private static IServiceCollection AddJsonService(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            return services;
        }
    }
}
