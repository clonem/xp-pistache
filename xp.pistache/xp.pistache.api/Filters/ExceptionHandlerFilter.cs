using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Authentication;
using FluentValidation;

namespace xp.pistache.api.Filters
{
    //REF: https://nwb.one/blog/exception-filter-attribute-dotnet
    //REF: https://briancaos.wordpress.com/2022/10/17/serialization-and-deserialization-of-system-intptr-instances-are-not-supported-path-targetsite-methodhandle-value/

    public class ExceptionHandlerFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is BusinessException)
            {
                // Trata ArgumentException como BadRequest
                context.Result = new BadRequestObjectResult(new { Error = context.Exception.Message });
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest; // HTTP 400 Bad Request
            }
            else if (context.Exception is ValidationException)
            {
                // Trata NotFoundException como NotFound
                context.Result = new BadRequestObjectResult(((ValidationException)context.Exception).Errors);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest; // HTTP 404 Not Found
            }
            //else
            //{
            //    // Qualquer outra exceção é tratada como Internal Server Error
            //    context.Result = new JsonResult(new
            //    {
            //        Error = "An unexpected error occurred. Please try again later.",
            //        Details = context.Exception.Message
            //    })
            //    {
            //        StatusCode = 500 // HTTP 500 Internal Server Error
            //    };
            //}

            // context.ExceptionHandled = true;
        }

        private static HttpStatusCode GetErrorCode(Exception e)
        {
            switch (e)
            {
                case FluentValidation.ValidationException _:
                case BusinessException _:
                // case ArgumentException _: somente utilizado para chamadas internas, ou seja caso aconteça e um internalServerErro
                case FormatException _:
                    return HttpStatusCode.BadRequest;
                //case NotFoundException _:
                //    return HttpStatusCode.NotFound;
                case AuthenticationException _:
                    return HttpStatusCode.Forbidden;
                case NotImplementedException _:
                    return HttpStatusCode.NotImplemented;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }
    }
}
