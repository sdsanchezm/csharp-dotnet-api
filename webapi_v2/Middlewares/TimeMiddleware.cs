// MiddlewareFactory ware here

namespace webapi.Middleware
{
    public class TimeMiddleware
    {
        readonly RequestDelegate next;

        public TimeMiddleware(RequestDelegate nextRequest)
        {
            next = nextRequest;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            if(context.Request.Query.Any(p => p.Key == "time"))
            {
                await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
                //return;
            }

            if (!context.Response.HasStarted)
            {
                await next.Invoke(context);
            }

            //await next(context);

        }

    }


    public static class TimeMiddlewareExtension
    {
        public static IApplicationBuilder UseTimeMiddlware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeMiddleware>();
        }
    }


}
