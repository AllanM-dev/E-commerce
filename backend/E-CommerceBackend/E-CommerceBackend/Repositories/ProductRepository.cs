using E_CommerceBackend.Entities;

namespace E_CommerceBackend.Repositories
{
    public class ProductRepository : GenericRepository<ProductModel>, IProductRepository
    {
        public ProductRepository(MyDbContext context)
            : base(context)
        {

        }
    }
}
