using Microsoft.AspNetCore.Mvc;
using Ntigra.Ecommerce.Platform.Application.Contract.Cart;
using Ntigra.Ecommerce.Platform.Web.Models;

namespace Ntigra.Ecommerce.Platform.Web.Controllers;
public sealed class CartController(ICartService cartService) : Controller
{
    public async Task<IActionResult> Add(int productId)
    {
        var response = await cartService.AddToCartAsync(productId);
        return response.Status ? RedirectToAction("Index") : View("Error", new ErrorViewModel
        {
            ErrorCode = response.ResponseCode,
            ErrorMessage = response.ResponseMessage
        });
    }

    public async Task<IActionResult> Remove(int productId)
    {
        var response = await cartService.RemoveFromCartAsync(productId);
        return response.Status ? RedirectToAction("Index") : View("Error", new ErrorViewModel
        {
            ErrorCode = response.ResponseCode,
            ErrorMessage = response.ResponseMessage
        });
    }

    public async Task<IActionResult> Index()
    {
        var response = await cartService.GetCartSummaryAsync();
        return response.Status ? View(response.Data) : View("Error", new ErrorViewModel
        {
            ErrorCode = response.ResponseCode,
            ErrorMessage = response.ResponseMessage
        });
    }
}
