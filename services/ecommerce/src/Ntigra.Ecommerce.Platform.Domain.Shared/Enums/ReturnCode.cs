using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ntigra.Ecommerce.Platform.Domain.Shared.Enums;

public enum ReturnCode
{
    SUCCESS,
    ALREADY_REGISTERED_EMAIL,
    UNHANDLED_EXCEPTION,
    CREATE_USER_BAD_REQUEST
}
