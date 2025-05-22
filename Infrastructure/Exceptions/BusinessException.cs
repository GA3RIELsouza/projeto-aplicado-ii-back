using System.Net;

namespace Projeto_Aplicado_II_API.Infrastructure.Exceptions
{
    public class BusinessException(string message, HttpStatusCode statusCode) : Exception(message)
    {
        public HttpStatusCode StatusCode { get; } = statusCode;
    }
}
