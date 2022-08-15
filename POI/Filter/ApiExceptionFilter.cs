using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace POI.Filter
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is Application.Exception.ValidationException)
            {
                HandleValidationException(context);
            }
            else
            {
                HandleUnknowException(context);
            }

            base.OnException(context);
        }

        private void HandleUnknowException(ExceptionContext context)
        {
            var exception = context.Exception;

            var details = new ValidationProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = exception.Message,
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }
        
        private void HandleValidationException(ExceptionContext context)
        {
            var exception = (Application.Exception.ValidationException)context.Exception;

            var details = new ValidationProblemDetails(exception.Errors)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }
    }
}
