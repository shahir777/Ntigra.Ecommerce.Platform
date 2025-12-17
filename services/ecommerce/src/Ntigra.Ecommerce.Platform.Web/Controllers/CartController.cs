using Microsoft.AspNetCore.Mvc;
using Ntigra.Ecommerce.Platform.Application.Contract.Cart;

namespace Ntigra.Ecommerce.Platform.Web.Controllers;
public sealed class CartController(ICartService cartService) : Controller
{
    public async Task<IActionResult> Add(int productId)
    {
        await cartService.AddToCartAsync(productId);
        var count = await cartService.GetCartItemCountAsync();

        return Json(new { success = true, count });
    }

    public async Task<IActionResult> Remove(int productId)
    {
        await cartService.RemoveFromCartAsync(productId);
        var count = await cartService.GetCartItemCountAsync();

        return Json(new { success = true, count });
    }

    public async Task<IActionResult> Index()
    {
        var summary = await cartService.GetCartSummaryAsync();
        return View(summary);
    }
}
