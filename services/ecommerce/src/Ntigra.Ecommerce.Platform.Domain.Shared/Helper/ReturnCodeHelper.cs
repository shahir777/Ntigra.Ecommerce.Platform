using Ntigra.Ecommerce.Platform.Domain.Shared.Enums;

namespace Ntigra.Ecommerce.Platform.Domain.Shared.Helper
{
    public static class ReturnCodeHelper
    {
        private static readonly Dictionary<ReturnCode, (string Code, string Message)> ResponseDetailsMap = new()
        {
            { ReturnCode.Success, ("200", "Operation successful.") },
            { ReturnCode.AlreadyRegisteredEmail, ("201", "This Email is Already Registered, Please try with different email.") },
            { ReturnCode.CreateUserBadRequest, ("202", "Full Name or Email is missing or empty. Please provide all the required fields and try again.") },
            { ReturnCode.UnhandledException, ("216", "An unexpected error occurred while processing the request.") },
            { ReturnCode.ProductNotFound, ("217", "Product list not found") },
            { ReturnCode.Fail, ("218", "Response failed") },
            { ReturnCode.CartEmpty, ("218", "Response failed") },
            { ReturnCode.DomainError, ("218", "Response failed") },
            { ReturnCode.DataError, ( "006", "Failed: '{0}'" ) },
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
