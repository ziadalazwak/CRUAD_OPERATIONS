using System.Diagnostics;

namespace L_1_dependcy_injection.MiddleWares
{
    public class Profiling_Middleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<Profiling_Middleware> _logger;
        public Profiling_Middleware(RequestDelegate next, ILogger<Profiling_Middleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            var stop_watch = new Stopwatch();
            stop_watch.Start();
            await _next(context);
            stop_watch.Stop();
            _logger.LogInformation($"Request'{context.Request.Path}' took '{stop_watch.ElapsedMilliseconds}ms' to excecute'");

        }
    }
}
