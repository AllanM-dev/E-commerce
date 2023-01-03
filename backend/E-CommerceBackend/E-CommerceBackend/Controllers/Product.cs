using E_CommerceBackend.Entities;
using E_CommerceBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Product
    {
        private readonly IProductService _productService;

        public Product(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Create a new Product
        /// </summary>
        /// <param name="product"></param>
        [HttpPost]
        public void PostProduct(
            [FromBody] ProductModel product)
        {
            _productService.CreateProduct(product);
        }

        /// <summary>
        /// Get list of products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ProductModel> GetProducts()
        {
            return _productService.GetAllProducts();
        }

        /// <summary>
        /// Get categories and product associated
        /// </summary>
        /// <returns></returns>
        [HttpGet("category")]
        public Dictionary<string, IEnumerable<ProductModel>> GetProductsByCategories()
        {
            return _productService.GetProductsByCategories();
        }
    }
}
