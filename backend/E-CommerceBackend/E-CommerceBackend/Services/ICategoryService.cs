using E_CommerceBackend.Entities;

namespace E_CommerceBackend.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category? GetCategoryByName(string categoryName);
        void CreateCategory(string categoryName);
    }
}
