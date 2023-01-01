using E_CommerceBackend.Entities;

namespace E_CommerceBackend.Repositories
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public void CreateProduct(Product product);
    }
}
