using E_CommerceBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Product
    {
        readonly IProductService _productService;

        public Product(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public void PostProduct(
            [FromBody] Entities.Product product)
        {
            _productService.CreateProduct(product);
        }

        [HttpGet]
        public IEnumerable<Entities.Product> GetProducts()
        {
            return _productService.GetAllProducts();
        }

        [HttpGet("category")]
        public Dictionary<string, IEnumerable<Entities.Product>> GetProductsByCategories()
        {
            return _productService.GetProductsByCategories();
        }
    }
}
