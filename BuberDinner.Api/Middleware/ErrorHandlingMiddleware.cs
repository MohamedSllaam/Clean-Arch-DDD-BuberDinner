using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BuberDinner.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
            // Middleware constructor logic
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                // Handle the exception
                await HandleErrorAsync(context, ex);
            }
        }
        public static Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            var result = JsonSerializer.Serialize(new
            {
                error ="An error occurred while processing your request.",
            });
            // Log the exception (not implemented here)
            context.Response.StatusCode = (int) code;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }           
 
    }
}