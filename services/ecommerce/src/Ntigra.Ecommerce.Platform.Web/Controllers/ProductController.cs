using Microsoft.AspNetCore.Mvc;
using Ntigra.Ecommerce.Platform.Application.Contract.Product;
using Ntigra.Ecommerce.Platform.Web.Models;

namespace Ntigra.Ecommerce.Platform.Web.Controllers
{
    public sealed class ProductController(IProductService productService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await productService.GetAllProductsAsync();
            return response.Status ? 
                View(response.Data) : View("Error", new ErrorViewModel
                {
                    ErrorCode = response.ResponseCode,
                    ErrorMessage = response.ResponseMessage
                });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                ErrorCode = "500",
                ErrorMessage = "Unexcpected error"
            });
            
        }
    }
}
