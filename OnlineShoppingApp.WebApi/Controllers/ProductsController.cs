using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingApp.Business.Operations.Product;
using OnlineShoppingApp.Business.Operations.Product.Dtos;
using OnlineShoppingApp.WebApi.Models;

namespace OnlineShoppingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        //Those with admin rights can send a request to add a product.
        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> AddProduct(AddProductRequest request)
        {
            var addProductDto = new AddProductDto
            {
                ProductName = request.ProductName,
                Price = request.Price,
                StockQantity = request.StockQantity,
            };

           var result = await _productService.AddProduct(addProductDto);

            if (result.IsSucceed)
                return Ok();
            else
                return BadRequest(result.Message);
        }
    }
}
