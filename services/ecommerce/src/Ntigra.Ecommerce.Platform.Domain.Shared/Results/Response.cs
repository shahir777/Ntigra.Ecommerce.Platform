using Ntigra.Ecommerce.Platform.Domain.Shared.Enums;
using Ntigra.Ecommerce.Platform.Domain.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntigra.Ecommerce.Platform.Domain.Shared.Results;
public class Response<T>
{
    public bool Status { get; set; }
    public string ResponseCode { get; set; }
    public string ResponseMessage { get; set; }
    public T Data { get; set; }
    public List<string> Errors { get; set; }

    protected Response(bool status, string responseCode, string responseMessage, T data = default, List<string> errors = default)
    {
        Status = status;
        ResponseCode = responseCode;
        ResponseMessage = responseMessage;
        Data = data;
        Errors = errors;
    }

    public static Response<T> Success(ReturnCode returnCode)
    {
        var (responseCode, responseMessage) = ReturnCodeHelper.GetResponseDetails(returnCode);
        return new Response<T>(true, responseCode, responseMessage, default);
    }

    public static Response<T> Success(ReturnCode returnCode, T data = default)
    {
        var (responseCode, responseMessage) = ReturnCodeHelper.GetResponseDetails(returnCode);
        return new Response<T>(true, responseCode, responseMessage, data);
    }

    public static Response<T> Success(ReturnCode returnCode, string message = null, T data = default)
    {
        var (responseCode, responseMessage) = ReturnCodeHelper.GetResponseDetails(returnCode);
        return new Response<T>(true, responseCode, message ?? responseMessage, data);
    }

    public static Response<T> Error(string responseCode, string message = null, List<string> errors = default)
    {
        //var (responseCode, responseMessage) = ReturnCodeHelper.GetResponseDetails(returnCode);
        return new Response<T>(false, responseCode, message, default, errors);
    }

    public static Response<T> Error(ReturnCode returnCode, string message = null, List<string> errors = default)
    {
        var (responseCode, responseMessage) = ReturnCodeHelper.GetResponseDetails(returnCode);
        return new Response<T>(false, responseCode, responseMessage, default, errors);
    }

    public static Response<T> Error(ReturnCode returnCode, T data, string message = null)
    {
        var (responseCode, responseMessage) = ReturnCodeHelper.GetResponseDetails(returnCode);
        return new Response<T>(false, responseCode, message ?? responseMessage, data, default);
    }
}

