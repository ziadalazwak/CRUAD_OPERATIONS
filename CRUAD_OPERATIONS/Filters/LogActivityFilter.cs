using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace L_1_dependcy_injection.Filters
{
    public class LogActivityFilter : IActionFilter
    {
        public ILogger<LogActivityFilter> logger { get; set; }
        public LogActivityFilter(ILogger<LogActivityFilter> logger) { this.logger = logger; }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation($"Executing action {context.ActionDescriptor.DisplayName} on controller {context.Controller}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation($" action {context.ActionDescriptor.DisplayName} finished excution  on controller {context.Controller}");
        }

       
    }
}
