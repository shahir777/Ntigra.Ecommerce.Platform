using Ntigra.Ecommerce.Platform.Domain.Shared.Exceptions;
using Ntigra.Ecommerce.Platform.Domain.Shared.Results;

namespace Ntigra.Ecommerce.Platform.Application.Contract.Cart;

public class Validator
{
    public Response<string> Validate(int productId)
    {
        if (productId <= 0)
            return RequestDataException.DataError<string>($"{nameof(productId)} must be greater than zero.");

        return null;
    }
}