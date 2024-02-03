using System.Diagnostics;
using System.Globalization;
using FileService;
namespace middleware;
public class ActionLogbMiddleware
{
    private readonly RequestDelegate _next;
    private Ilog _myLog;
    public ActionLogbMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context,Ilog myLog)
    {
        _myLog=myLog;
        myLog.WriteMessageToLog("response date:"+DateTime.Now+"\n");
        myLog.WriteMessageToLog("method:"+context.Request.Method+"\n");
        myLog.WriteMessageToLog("request body:"+context.Request.Body+"\n");
        myLog.WriteMessageToLog("request headers:"+context.Request.Headers+"\n");
        // Call the next delegate/middleware in the pipeline.
        await _next(context);
        myLog.WriteMessageToLog("the request date:"+DateTime.Now+"\n");
        myLog.WriteMessageToLog("response status:"+context.Response.StatusCode+"\n");
        myLog.WriteMessageToLog("response body:"+context.Response.Body+"\n\n");
        
    }

}