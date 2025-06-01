using Projeto_Aplicado_II_API.Infrastructure.Exceptions;
using System.Net;

namespace Projeto_Aplicado_II_API.Infrastructure.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string message;

            if (exception is BusinessException businessException)
            {
                message = businessException.Message;
                context.Response.StatusCode = (int)businessException.StatusCode;
            }
            else
            {
                message = exception.ToString();
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(message);
        }
    }
}
