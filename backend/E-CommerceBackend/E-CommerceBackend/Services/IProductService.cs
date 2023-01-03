using E_CommerceBackend.Entities;

namespace E_CommerceBackend.Services
{
    public interface IProductService
    {
        public IEnumerable<ProductModel> GetAllProducts();
        public void CreateProduct(ProductModel product);
        public Dictionary<string, IEnumerable<ProductModel>> GetProductsByCategories();
    }
}
