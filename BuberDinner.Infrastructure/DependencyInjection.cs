using System.Text;
using BuberDinner.Application.Common.InterFaces.Authentication;
using BuberDinner.Application.Common.InterFaces.Presistence;
using BuberDinner.Application.Common.InterFaces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Persistence;
using BuberDinner.Infrastructure.Presistence;
using BuberDinner.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services
            .AddAuth(configurationManager)
            .AddPersistance();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            // Register your infrastructure services here
            // For example, you might register a database context or external API clients

            return services;
        }

        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
 services.AddDbContext<BuberDinnerDbContext>(options =>
     options.UseSqlServer("Server=sql-data;Database=BuberDinner;User Id=sa;Password=amiko123!;TrustServerCertificate=True"));


            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>(); 
            return services;
         }
        public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            // Register your API controllers, filters, and other presentation layer components here

            // services.Configure<ApiBehaviorOptions>(options =>
            // {
            //     options.SuppressModelStateInvalidFilter = true; // Suppress default validation behavior
            // });
           // var jwtSettings = configurationManager.GetSection(JwtSettings.SectionName).Get<JwtSettings>();
             var jwtSettings = new JwtSettings();
            configurationManager.Bind(JwtSettings.SectionName, jwtSettings);    
             services.AddSingleton(Options.Create( jwtSettings));
            // Alternatively, you can use the following line if you prefer to bind the configuration section directly
            // services.Configure<JwtSettings>(configurationManager.GetSection(JwtSettings.SectionName));
            
            // If you want to use IOptions<JwtSettings> instead of a singleton
           // services.Configure<JwtSettings>(configurationManager.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSettings.Secret))
                };
            });
               
           
         return services;
        }
    }
     }