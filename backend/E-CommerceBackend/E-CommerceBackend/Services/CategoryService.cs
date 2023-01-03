using E_CommerceBackend.Entities;
using E_CommerceBackend.Repositories;

namespace E_CommerceBackend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _catRepository;
        public CategoryService(ICategoryRepository catRepository)
        {
            _catRepository = catRepository;
        }

        /// <summary>
        /// Create a new category if the name doesn't exist
        /// </summary>
        /// <param name="categoryName">Category Name</param>
        public void CreateCategory(string categoryName)
        {
            var existingCategory = _catRepository.GetCategoryByName(categoryName);
            if (existingCategory == null)
            {
                CategoryModel category = new() { Name = categoryName };
                _catRepository.Create(category);
            }
        }

        /// <summary>
        /// Get all existing categories 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CategoryModel> GetAllCategories()
        {
            return _catRepository.GetAll();
        }

        /// <summary>
        /// Get a category with a specific name
        /// </summary>
        /// <param name="categoryName">Category Name</param>
        /// <returns>The Category if she exists else null</returns>
        public CategoryModel? GetCategoryByName(string categoryName)
        {
            return _catRepository.GetCategoryByName(categoryName);
        }
    }
}
