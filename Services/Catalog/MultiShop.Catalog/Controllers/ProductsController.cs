using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var Product = await _productService.GetAllProductsAsync();
            return Ok(Product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var Product = await _productService.GetProductByIdAsync(id);
            return Ok(Product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok("Product Added Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok("Product Updated Successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Product Deleted Successfully");
        }

        [HttpGet("GetAllProductsWithCategory")]
        public async Task<IActionResult> GetAllProductsWithCategory()
        {
            var product = await _productService.GetAllProductsWithCategoryAsync();
            return Ok(product);
        }

        [HttpGet("GetAllProductsWithCategoryByCategoryId")]
        public async Task<IActionResult> GetAllProductsWithCategoryByCategoryId(string categoryId)
        {
            var products = await _productService.GetAllProductsWithCategoryByCategoryIdAsync(categoryId);
            return Ok(products);
        }
    }
}
