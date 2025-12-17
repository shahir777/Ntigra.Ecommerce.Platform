using System.Net;
using Ntigra.Ecommerce.Platform.Domain.Shared.Enums;
using Ntigra.Ecommerce.Platform.Domain.Shared.Helper;
using Ntigra.Ecommerce.Platform.Domain.Shared.Results;

namespace Ntigra.Ecommerce.Platform.Domain.Shared.Exceptions;

public class RequestDataException(string message)
    : AppException(ReturnCode.DataError, HttpStatusCode.BadRequest, message)
{
    public static Response<T> DataError<T>(string fieldName, ReturnCode returnCode = ReturnCode.DataError)
    {
        var (responseCode, responseMessage) = ReturnCodeHelper.GetResponseDetails(returnCode, fieldName);
        return Response<T>.AppException(responseCode, responseMessage);
    }
}