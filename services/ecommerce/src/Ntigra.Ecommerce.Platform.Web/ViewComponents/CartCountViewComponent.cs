using Microsoft.AspNetCore.Mvc;
using Ntigra.Ecommerce.Platform.Application.Contract.Cart;
namespace Ntigra.Ecommerce.Platform.Web.ViewComponents;
public class CartCountViewComponent(ICartService cartService) : ViewComponent
{ 
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var count = await cartService.GetCartItemCountAsync();
        return View(count);
    }
}
