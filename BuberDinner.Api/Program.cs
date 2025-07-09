using BuberDinner.Api;
using BuberDinner.Api.Errors;
using BuberDinner.Api.Filters;
using BuberDinner.Api.Mapping;
using BuberDinner.Api.Middleware;
using BuberDinner.Application;
using BuberDinner.Application.Authentication;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.
    AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
}
var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }
    //app.UseMiddleware<ErrorHandlingMiddleware>();  
    app.UseExceptionHandler("/error");
    // app.Map("/error", (HttpContext context) =>
    // {
    //     Exception? exception = context.Features.Get<IExceptionHandlerFeature>()?.Error; 
    //     return Results.Problem();
    // });     
    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();

}