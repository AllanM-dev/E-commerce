using E_CommerceBackend.Entities;

namespace E_CommerceBackend.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAllProducts();
        public void CreateProduct(Product product);
        public Dictionary<string, IEnumerable<Product>> GetProductsByCategories();
    }
}
