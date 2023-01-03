using E_CommerceBackend.Entities;

namespace E_CommerceBackend.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryModel> GetAllCategories();
        CategoryModel? GetCategoryByName(string categoryName);
        void CreateCategory(string categoryName);
    }
}
