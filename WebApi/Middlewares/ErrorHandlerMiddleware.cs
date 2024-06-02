using Application.Exceptions;
using Application.Wrappers;
using System.Net;
using System.Text.Json;

namespace WebApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var respose = context.Response;
                respose.ContentType = "application/json";
                var responseType = new ApiResponse<string> { Succeeded = false, Message=ex.Message };
                switch (ex)
                {
                    case ApiExceptions e:
                        respose.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case ValidationErrorException e:
                        respose.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseType.Errors = e.Errors;
                        break;
                    default:
                        respose.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;

                }
                var result = JsonSerializer.Serialize(responseType);
                await respose.WriteAsync(result); 
            }
        }
    }
}
