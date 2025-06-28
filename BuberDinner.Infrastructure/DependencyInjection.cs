using BuberDinner.Application.Common.InterFaces.Authentication;
using BuberDinner.Application.Common.InterFaces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinner.Infrastructure
{
    public static class DependencyInjection
    {
 
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configurationManager  )
        {
            services.Configure<JwtSettings>(configurationManager.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            // Register your infrastructure services here
            // For example, you might register a database context or external API clients

            return services;
        }
    }
}