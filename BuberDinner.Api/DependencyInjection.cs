using BuberDinner.Api.Errors;
using BuberDinner.Api.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
          services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
          services.AddOpenApi();
//builder.Services.AddControllers(options=> options.Filters.Add<ErrorHandlingExceptionFilterAttribute>());

services.AddControllers();
            //services.AddScoped<ErrorHandlingExceptionFilterAttribute>();
            //services.AddScoped<ErrorHandlingMiddleware>();
            services.AddMapping();
            return services;
        }
        

    }
}