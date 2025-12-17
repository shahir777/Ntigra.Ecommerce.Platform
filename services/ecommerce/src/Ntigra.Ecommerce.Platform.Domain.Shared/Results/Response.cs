using Ntigra.Ecommerce.Platform.Domain.Shared.Enums;
using Ntigra.Ecommerce.Platform.Domain.Shared.Helper;

namespace Ntigra.Ecommerce.Platform.Domain.Shared.Results;
public class Response<T>
{
    public bool Status { get; set; }
    public string ResponseCode { get; set; }
    public string ResponseMessage { get; set; }
    public T Data { get; set; }
    public List<string> Errors { get; set; }

    private Response(bool status, string responseCode, string responseMessage, T data = default, List<string> errors = default)
    {
        Status = status;
        ResponseCode = responseCode;
        ResponseMessage = responseMessage;
        Data = data;
        Errors = errors;
    }

    public static Response<T> Success(ReturnCode returnCode = ReturnCode.Success, string? message = null, T data = default)
    {
        var (responseCode, responseMessage) = ReturnCodeHelper.GetResponseDetails(returnCode);
        return new Response<T>(true, responseCode, message ?? responseMessage, data);
    }

    public static Response<T> Fail(ReturnCode returnCode = ReturnCode.Fail, string? message = null, List<string> errors = default)
    {
        var (responseCode, responseMessage) = ReturnCodeHelper.GetResponseDetails(returnCode);
        return new Response<T>(false, responseCode, message ?? responseMessage, errors: errors);
    }
    
    public static Response<T> AppException(string responseCode, string responseMessage) =>
        new(false, responseCode, responseMessage);
    
}

