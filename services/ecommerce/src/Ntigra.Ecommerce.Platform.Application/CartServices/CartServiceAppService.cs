using Microsoft.Extensions.Logging;
using Ntigra.Ecommerce.Platform.Application.Contract.Cart;
using Ntigra.Ecommerce.Platform.Domain.Cart;
using Ntigra.Ecommerce.Platform.Domain.Managers;
using Ntigra.Ecommerce.Platform.Domain.Shared.Enums;
using Ntigra.Ecommerce.Platform.Domain.Shared.Exceptions;
using Ntigra.Ecommerce.Platform.Domain.Shared.Helper;
using Ntigra.Ecommerce.Platform.Domain.Shared.Helper.Extensions;
using Ntigra.Ecommerce.Platform.Domain.Shared.Results;

namespace Ntigra.Ecommerce.Platform.Application.CartServices;
public sealed class CartServiceAppService(ICartRepository cartRepository,
    DiscountManager discountManager,
    Validator validator,
    ILogger<CartServiceAppService> log) : ICartService
{
    private const decimal PriceThreshold = 100;

    public async Task<Response<string>> AddToCartAsync(int productId)
    {
        try
        {
            var validationResult = validator.Validate(productId);

            if (validationResult is not null)
            {
                log.Error($"Validation error: {validationResult}");
                return validationResult;
            }

            log.Info($"Adding product: {productId} to cart");
            await cartRepository.AddAsync(productId);
            return Response<string>.Success(message: "Product added to cart");
        }
        catch (AppException ex)
        {
            log.Exception(ex);
            return Response<string>.AppException(ex.ResponseCode, ex.ResponseMessage);
        }
        catch (Exception ex)
        {
            log.Exception(ex);
            return Response<string>.Fail(message: ex.Message);
        }
    }

    public async Task<Response<string>> RemoveFromCartAsync(int productId) 
    {
        try
        {
            var validationResult = validator.Validate(productId);

            if (validationResult is not null)
            {
                log.Error($"Validation error: {validationResult}");
                return validationResult;
            }
            
            log.Info($"Removing product: {productId} from cart");
            await cartRepository.RemoveAsync(productId);
            return Response<string>.Success(message: "Product removed from cart");
        }
        catch (AppException ex)
        {
            log.Exception(ex);
            return Response<string>.AppException(ex.ResponseCode, ex.ResponseMessage);
        }
        catch (Exception ex)
        {
            log.Exception(ex);
            return Response<string>.Fail(message: ex.Message);
        }
    }

    public async Task<Response<CartSummaryResponseDto>> GetCartSummaryAsync()
    {
        try
        {
            log.Debug("Getting cart summary");
            var cartItems = await cartRepository.GetCartItemsAsync();
            var hasDiscount = discountManager.HasDiscount(cartItems);
            
            log.Debug($"Cart Items fetched from DB: {JsonHelper.SerializeWithOptions(cartItems)}");
            
            var items = cartItems.Select(item =>
            {
                var discount = discountManager.CalculateItemDiscount(item, hasDiscount);

                return new CartItemSummary
                {
                    ProductId = item.Product.Id,
                    ProductName = item.Product.Name,
                    Description = item.Product.Description,
                    OriginalPrice = item.Product.Price,
                    DiscountPercent = item.Product.DiscountPercent,
                    DiscountAmount = discount,
                    Quantity = item.Quantity,
                };
                
            }).ToList();

            var response = new CartSummaryResponseDto
            {
                Items = items,
                TotalPrice = cartItems.Sum(item => item.Product.Price * item.Quantity),
                TotalDiscount = items.Sum(item => item.DiscountAmount * item.Quantity)
            };

            log.Debug($"Response: {JsonHelper.SerializeWithOptions(response)}");
            
            if (response.Items.Count > 0)
            {
                log.Success($"Cart items found: {response.Items.Count}");
                return Response<CartSummaryResponseDto>.Success(data: response);
            }
            
            return Response<CartSummaryResponseDto>.Success(ReturnCode.CartEmpty, data: response);
        }
        catch (AppException ex)
        {
            log.Exception(ex);
            return Response<CartSummaryResponseDto>.AppException(ex.ResponseCode, ex.ResponseMessage);
        }
        catch (Exception ex)
        {
            log.Exception(ex);
            return Response<CartSummaryResponseDto>.Fail(message: ex.Message);
        }
    }
}