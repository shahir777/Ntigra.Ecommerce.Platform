using System.Net;
using Ntigra.Ecommerce.Platform.Domain.Shared.Enums;

namespace Ntigra.Ecommerce.Platform.Domain.Shared.Exceptions;

public class DomainException : AppException
{
    public DomainException(string message) : base(ReturnCode.DomainError, HttpStatusCode.InternalServerError, message){}
}