using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace L_1_dependcy_injection.Filters
{
    public class LogsensActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {

            Debug.WriteLine("Sens action excuted !!!!!");

        }

    }
}
