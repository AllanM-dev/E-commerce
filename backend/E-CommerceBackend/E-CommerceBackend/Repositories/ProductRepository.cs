using E_CommerceBackend.Entities;

namespace E_CommerceBackend.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private LibraryContext _libraryContext;
        public ProductRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public void CreateProduct(Product product)
        {
            _libraryContext.Products.Add(product);
            Category myCategory = _libraryContext.Categories.FirstOrDefault(cat => cat.Id == product.CategoryId);
            if (myCategory != null)
            {
                _libraryContext.Products.Add(product);
                myCategory.Products.Add(product);
                _libraryContext.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _libraryContext.Products;
        }
    }
}
