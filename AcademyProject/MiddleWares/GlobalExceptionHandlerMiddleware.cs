using Application.Common.Exceptions;
using Application.Common.Models;
using Newtonsoft.Json;
using System.Net;

namespace AcademyProject.MiddleWares
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var failureResponse = new RespDto<bool>().Get500Error($"Internal Servre Error,{exception.Message}");

            switch (exception)
            {
                case ValidationException validationException:
                    failureResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    failureResponse.Message = exception.Message;
                    failureResponse.Message = JsonConvert.SerializeObject(validationException.Failures);
                    break;
                case BadRequestException badRequestException:
                    failureResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    failureResponse.Message = badRequestException.Message;
                    break;
                case NotFoundException _:
                    failureResponse.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 200;

            if (failureResponse.Message == string.Empty)
            {
                failureResponse.Message = JsonConvert.SerializeObject(new { error = exception.Message });
            }

            return context.Response.WriteAsync(JsonConvert.SerializeObject(failureResponse));
        }
    }

    public static class GlobalExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionHandlerMiddleware>();
        }
    }
}
