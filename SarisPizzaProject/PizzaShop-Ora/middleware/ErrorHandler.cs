using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
namespace middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);  
            }
            catch (Exception ex)
            {
                Console.WriteLine("there was an error😭");
                throw ex;
            }
        }
    }
    }