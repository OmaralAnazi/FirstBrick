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
    public static readonly ApiException Credentials = new ApiException("Invalid email or password", HttpStatusCode.Unauthorized, "E0002");
    public static readonly ApiException UserNotFound = new ApiException("User not found", HttpStatusCode.NotFound, "E0003");
    public static readonly ApiException WalletNotFound = new ApiException("Wallet not found", HttpStatusCode.NotFound, "E0004");
    public static readonly ApiException InsufficientBalance = new ApiException("Insufficient balance", HttpStatusCode.BadRequest, "E0005");
}

