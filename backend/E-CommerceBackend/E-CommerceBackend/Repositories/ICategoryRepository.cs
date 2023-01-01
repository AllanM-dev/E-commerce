using E_CommerceBackend.Entities;

namespace E_CommerceBackend.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        Category? GetCategoryByName(string categoryName);
        void CreateCategory(string categoryName);
    }
}
