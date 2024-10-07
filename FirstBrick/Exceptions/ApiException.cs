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
    public static readonly ApiException FundNotFound = new ApiException("Fund not found", HttpStatusCode.NotFound, "E0006");
    public static readonly ApiException UnitsBelowMinimum = new ApiException("The number of units is below the minimum allowed", HttpStatusCode.BadRequest, "E0007");
    public static readonly ApiException UnitsExceedAvailable = new ApiException("The number of units exceeds the available units", HttpStatusCode.BadRequest, "E0008");
    public static readonly ApiException InvestmentNotFound = new ApiException("Investment not found", HttpStatusCode.NotFound, "E0009");
}

