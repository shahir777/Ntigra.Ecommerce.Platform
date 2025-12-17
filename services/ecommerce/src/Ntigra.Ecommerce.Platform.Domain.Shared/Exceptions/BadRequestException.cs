using Ntigra.Ecommerce.Platform.Domain.Shared.Enums;
using Ntigra.Ecommerce.Platform.Domain.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ntigra.Ecommerce.Platform.Domain.Shared.Exceptions
{
    public class BadRequestException : AppException
    {
        public BadRequestException(ReturnCode code)
            : base(
                code,
                HttpStatusCode.BadRequest)
        { }

    }
}
