using Mapster;
using MapsterMapper;

namespace BuberDinner.Api.Mapping
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
          var config = TypeAdapterConfig.GlobalSettings;
            // Register Mapster
           config.Scan(typeof(DependencyInjection).Assembly);
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            
            return services;
        }   

    }
}