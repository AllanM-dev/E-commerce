using E_CommerceBackend.Entities;
using E_CommerceBackend.Repositories;

namespace E_CommerceBackend.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public void CreateProduct(Product product)
        {
            _productRepository.CreateProduct(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Dictionary<string, IEnumerable<Product>> GetProductsByCategories()
        {
            var categoriesDict = new Dictionary<string, IEnumerable<Product>>();
            var categories = _categoryRepository.GetAllCategories();
            var allProducts = _productRepository.GetAllProducts();
            foreach (Category category in categories)
            {
                var myProducts = allProducts.Where(x => x.CategoryId == category.Id);
                categoriesDict.Add(category.Name, myProducts);
            }
            return categoriesDict;
            
        }
    }
}
