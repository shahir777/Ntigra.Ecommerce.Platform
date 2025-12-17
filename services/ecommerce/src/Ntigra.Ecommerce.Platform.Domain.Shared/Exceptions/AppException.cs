using System.Net;
using Ntigra.Ecommerce.Platform.Domain.Shared.Enums;
using Ntigra.Ecommerce.Platform.Domain.Shared.Helper;

namespace Ntigra.Ecommerce.Platform.Domain.Shared.Exceptions;
public class AppException : Exception
{
    public object Data { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }
    public string ResponseCode { get; set; }
    public string ResponseMessage { get; set; }

    protected AppException(
        ReturnCode returnCode, 
        HttpStatusCode httpStatusCode,
        string? message = null,
        object? data = null, 
        Exception? innerException = null) : base(message, innerException)
    {
        var details = ReturnCodeHelper.GetResponseDetails(returnCode);
        HttpStatusCode = httpStatusCode;
        Data = data;
        ResponseCode = details.ResponseCode;
        ResponseMessage = message ?? details.ResponseMessage;
    }
}

