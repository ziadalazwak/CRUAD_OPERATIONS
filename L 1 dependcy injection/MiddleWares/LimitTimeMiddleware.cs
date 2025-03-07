namespace L_1_dependcy_injection.MiddleWares
{
    public class LimitTimeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LimitTimeMiddleware> logger;
        private static int counter = 0;
        private static DateTime _LastRequestDate = DateTime.Now;
        public LimitTimeMiddleware(RequestDelegate next, ILogger<LimitTimeMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            counter++;
            if (DateTime.Now.Subtract(_LastRequestDate).Seconds > 10)
            {
                _LastRequestDate = DateTime.Now;
                counter = 1;
                await _next(context);
            }
            else
            {
                if (counter > 5)
                {
                    _LastRequestDate = DateTime.Now;
                    await context.Response.WriteAsync("Rate limit exceeded");
                }
                else { _LastRequestDate = DateTime.Now; await _next(context); }
            }
        }
    }
}
