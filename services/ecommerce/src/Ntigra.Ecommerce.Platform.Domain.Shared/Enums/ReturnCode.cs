using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntigra.Ecommerce.Platform.Domain.Shared.Enums;

public enum ReturnCode
{
    Success,
    Fail,
    AlreadyRegisteredEmail,
    UnhandledException,
    CreateUserBadRequest,
    ProductNotFound,
    DomainError,
    CartEmpty,
    DataError
}
