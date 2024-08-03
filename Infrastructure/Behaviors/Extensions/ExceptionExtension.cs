using Domain.Behaviors;
using Infrastructure.Behaviors.Middlewares.GlobalException.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Infrastructure.Behaviors.Extensions
{
    public static class ExceptionExtension
    {
        public static ProblemDetails GenerateResult(this Exception exception, HttpContext httpContext, ILogger logger)
        {
            var result = new ExceptionViewModel();
            result.Title = "An unexpected error occurred";
            result.Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}";

            switch (exception)
            {
                case ArgumentNullException argumentNullException:
                    result = new ExceptionViewModel
                    {
                        Status = (int)HttpStatusCode.NotFound,
                        Type = argumentNullException.GetType().Name,
                        Detail = argumentNullException.Message,
                        Errors = new List<string> { argumentNullException.Message },
                    };
                    break;
                case ValidationException validationException:
                    result = new ExceptionViewModel
                    {
                        Status = (int)HttpStatusCode.BadRequest,
                        Type = validationException.GetType().Name,
                        Detail = validationException.Message,
                        Errors = validationException.Errors,
                    };
                    break;
                case FluentValidation.ValidationException fluentException:
                    result = new ExceptionViewModel
                    {
                        Status = (int)HttpStatusCode.BadRequest,
                        Type = fluentException.GetType().Name,
                        Detail = fluentException.Message,
                    };
                    result.Extensions.Add("Errors", fluentException.Errors);
                    break;
                case NotFoundException notFoundException:
                    result = new ExceptionViewModel
                    {
                        Status = (int)HttpStatusCode.NotFound,
                        Type = notFoundException.GetType().Name,
                        Detail = notFoundException.Message,
                        Errors = notFoundException.Errors,
                    };
                    break;
                case InternalServerErrorException internalException:
                default:
                    result = new ExceptionViewModel
                    {
                        Status = (int)HttpStatusCode.InternalServerError,
                        Type = exception.GetType().Name,
                        Detail = exception.Message,
                        Errors = new List<string> { exception.Message },
                    };
                    break;
            }
            logger.LogError(exception, $"EXCEPTION: {result.ToString()}");
            return result;
        }
    }
}
