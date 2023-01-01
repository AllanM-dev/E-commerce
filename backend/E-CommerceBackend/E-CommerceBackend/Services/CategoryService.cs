using E_CommerceBackend.Entities;
using E_CommerceBackend.Repositories;

namespace E_CommerceBackend.Services
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository _catRepository;
        public CategoryService(ICategoryRepository catRepository)
        {
            _catRepository = catRepository;
        }

        public void CreateCategory(string categoryName)
        {
            var existingCategory = _catRepository.GetCategoryByName(categoryName);
            if (existingCategory == null)
            {
                _catRepository.CreateCategory(categoryName);
            }
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _catRepository.GetAllCategories();
        }

        public Category? GetCategoryByName(string categoryName)
        {
            return _catRepository.GetCategoryByName(categoryName);
        }
    }
}
