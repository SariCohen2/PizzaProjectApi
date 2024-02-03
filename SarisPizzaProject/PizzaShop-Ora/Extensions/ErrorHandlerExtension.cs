using middleware;
// using Extensions;
namespace Extensions
{
    public static class ErrorHandlerExtension
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
