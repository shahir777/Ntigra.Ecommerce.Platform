using Ntigra.Ecommerce.Platform.Domain.Shared.Enums;
using Ntigra.Ecommerce.Platform.Domain.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ntigra.Ecommerce.Platform.Domain.Shared.Exceptions;
public class AppException : Exception
{
    public object Data { get; set; }
    public HttpStatusCode HttpStatusCode { get; set; }
    public string ResponseCode { get; set; }
    public string ResponseMessage { get; set; }

    public AppException(
        ReturnCode returnCode, 
        HttpStatusCode httpStatusCode,
        string message = null,
        object data = null, 
        Exception innerException = null)
    {
        var details = ReturnCodeHelper.GetResponseDetails(returnCode);
        HttpStatusCode = httpStatusCode;
        Data = data;
        ResponseCode = details.ResponseCode;
        ResponseMessage = details.ResponseMessage;
    }
}

