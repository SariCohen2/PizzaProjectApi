using middleware;
namespace Extensions;
public static class ActionLogbMiddlewareExtension
{
    public static IApplicationBuilder UseActionLog(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ActionLogbMiddleware>();
    }
}