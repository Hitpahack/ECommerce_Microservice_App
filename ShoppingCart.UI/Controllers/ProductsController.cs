using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingCart.UI.Models;
using ShoppingCart.UI.Services;

namespace ShoppingCart.UI.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDto> list = new();
            var response = await _productService.GetAllProducts<ResponseDto>();
            if (response != null && response.IsSuccess == true) {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response));
            }

            return View();
        }
    }
}
