using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PlatformService.Web.Filters
{
    public class ExceptionHandlingFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled &&
                 filterContext.Exception is System.Exception exception)
            {
                filterContext.Result = new BadRequestObjectResult(
                    new
                    {
                        errorMessage = exception.Message
                    });
                filterContext.ExceptionHandled = true;
            }
        }
    }
}
