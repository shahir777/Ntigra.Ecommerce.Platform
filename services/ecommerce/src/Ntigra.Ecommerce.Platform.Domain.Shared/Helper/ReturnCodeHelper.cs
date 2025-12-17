using Ntigra.Ecommerce.Platform.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntigra.Ecommerce.Platform.Domain.Shared.Helper
{
    public static class ReturnCodeHelper
    {
        private readonly static Dictionary<ReturnCode, (string Code, string Message)> ResponseDetailsMap = new()
        {
            { ReturnCode.SUCCESS, ("200", "Operation successful.") },
            { ReturnCode.ALREADY_REGISTERED_EMAIL, ("201", "This Email is Already Registered, Please try with different email.") },
            { ReturnCode.CREATE_USER_BAD_REQUEST, ("202", "Full Name or Email is missing or empty. Please provide all the required fields and try again.") },
            { ReturnCode.UNHANDLED_EXCEPTION, ("216", "An unexpected error occurred while processing the request.") },
        };

        public static (string ResponseCode, string ResponseMessage) GetResponseDetails(ReturnCode code, string fieldName = null)
        {
            if (ResponseDetailsMap.TryGetValue(code, out var details))
            {
                return (details.Code, string.Format(details.Message, fieldName));
            }
            return ("001", "An unknown error occurred.");
        }
    }
}
