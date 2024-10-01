using System.Net;

namespace FirstBrick.Exceptions;

public class ApiException : Exception
{
    public HttpStatusCode StatusCode { get; private set; }
    public string ErrorCode { get; private set; }

    public ApiException(string message, HttpStatusCode statusCode, string errorCode)
        : base(message)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }
}

public static class ApiExceptions
{
    public static readonly ApiException Unauthorized = new ApiException("Unauthorized", HttpStatusCode.Unauthorized, "E0001");
}

