using E_CommerceBackend.Entities;
using E_CommerceBackend.Repositories;

namespace E_CommerceBackend.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Create a new Product if the category associated exist
        /// </summary>
        /// <param name="product"></param>
        public void CreateProduct(ProductModel product)
        {
            var categories = _categoryRepository.GetAll();
            if(categories.Where(c => c.Id == product.CategoryId).Any())
            {
                _productRepository.Create(product);
            }
        }

        /// <summary>
        /// Get all existing products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductModel> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        /// <summary>
        /// Get Categories and Product associated
        /// </summary>
        /// <returns>Dictionary with the name of the category as key and the list of product as value</returns>
        public Dictionary<string, IEnumerable<ProductModel>> GetProductsByCategories()
        {
            var categoriesDict = new Dictionary<string, IEnumerable<ProductModel>>();
            var categories = _categoryRepository.GetAll();
            var allProducts = _productRepository.GetAll();
            foreach (CategoryModel category in categories)
            {
                var myProducts = allProducts.Where(x => x.CategoryId == category.Id);
                categoriesDict.Add(category.Name, myProducts);
            }
            return categoriesDict;
            
        }
    }
}
