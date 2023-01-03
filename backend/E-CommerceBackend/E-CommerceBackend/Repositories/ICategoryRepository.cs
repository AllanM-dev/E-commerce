using E_CommerceBackend.Entities;

namespace E_CommerceBackend.Repositories
{
    public interface ICategoryRepository : IGenericRepository<CategoryModel>
    {
        CategoryModel? GetCategoryByName(string categoryName);
    }
}
